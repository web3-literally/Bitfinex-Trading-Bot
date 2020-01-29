using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Capital Distribution Strategy Bot
/// </summary>

namespace CDSBot
{
    public partial class MainUI : Form
    {
        public static event UIEvent UIEventListener;
        private delegate void LogicEventHander(LOGIC_EVENT evt, Object param);
        private readonly object orderLock = new object();
        private readonly object positionLock = new object();

        public MainUI()
        {
            InitializeComponent();

            comboTicker.Items.AddRange(Global._tickerPricePairs.Keys.ToArray());
            foreach (object item in comboTicker.Items)
            {
                if (Convert.ToString(item) == Global._shortOrderParam.TickerChoice.Pair)
                {
                    comboTicker.SelectedItem = item;
                }
            }

            txtApiPublicKey.Text = Global.API_PUBLIC_KEY;
            txtApiSecretKey.Text = Global.API_SECRET_KEY;
            textPreview.ReadOnly = true;

            comboDistribution.SelectedIndex = (int)Global._shortOrderParam.DistributionType;
            spinLowerPrice.Value = (decimal)Global._shortOrderParam.LowerPrice;
            spinUpperPrice.Value = (decimal)Global._shortOrderParam.UpperPrice;
            spinCoefficient.Value = (decimal)Global._shortOrderParam.Coefficient;
            spinMinSize.Value = (decimal)Global._shortOrderParam.MinSize;
            spinAmount.Value = (decimal)Global._shortOrderParam.Amount;
            spinOrderCount.Value = (decimal)Global._shortOrderParam.OrderCount;

            spinProfitTarget.Value = (decimal)Global._conditionalOrderParam.ProfitTarget;
            spinProfitPercent.Value = (decimal)Global._conditionalOrderParam.ProfitPercent;
            spinDistance.Value = (decimal)Global._conditionalOrderParam.Distance;
            spinFee.Value = (decimal)Global._conditionalOrderParam.Fee;
            radioProfitTarget.Checked= Global._conditionalOrderParam.TargetOrPercent;
            radioProfitPercent.Checked = !Global._conditionalOrderParam.TargetOrPercent;

            UpdateBtnStatus(LOGIC_EVENT.INIT_STEP);
            MainController.LogicEventListener += new LogicEvent(this.OnLogicEvent);
        }

        private void OnLogicEvent(LOGIC_EVENT evt, Object param)
        {
            this.BeginInvoke(new LogicEventHander(this.OnLogicEventHandler), evt, param);
        }

        private void OnLogicEventHandler(LOGIC_EVENT evt, object param)
        {
            switch (evt)
            {
                case LOGIC_EVENT.API_SERVER_DISCONNECTED:
                    gridWallet.Rows.Clear();
                    break;
                case LOGIC_EVENT.WALLETS_SNAPSHOT:
                    {
                        gridWallet.Rows.Clear();
                        object[][] balances = ((IEnumerable)param).Cast<Wallet>()
                                            .OrderBy(x => x.Currency)
                                            .Select(x => x.ToDisplayDatas() )
                                     .ToArray();
                        foreach (object[] row in balances)
                        {
                            gridWallet.Rows.Add(row);
                        }
                        break;
                    }
                case LOGIC_EVENT.WALLET_UPDATE:
                    {
                        var wallet = (Wallet)param;
                        bool matched = false;
                        for (int index = 0; index < gridWallet.Rows.Count; index++)
                        {
                            DataGridViewRow row = gridWallet.Rows[index];
                            if (Convert.ToString(row.Cells[0].Value) == wallet.Currency)
                            {
                                gridWallet.Rows[index].Cells[1].Value = wallet.Amount;
                                matched = true;
                                break;
                            }
                        }
                        if (!matched)
                        {
                            gridWallet.Rows.Add(wallet.ToDisplayDatas());
                        }
                        break;
                    }
                case LOGIC_EVENT.BALANCES_LOAD_FAILED:
                    MessageBox.Show("Balances loading failed", "error");
                    break;
                case LOGIC_EVENT.TICKERS_LOADED:
                    {
                        comboTicker.Items.Clear();
                        object[] tickers = ((IEnumerable)param).Cast<Ticker>()
                                            .Select(x => x).ToArray();
                        foreach (object row in tickers)
                        {
                            comboTicker.Items.Add(row);
                            if (((Ticker)row).Pair == Global._shortOrderParam.TickerChoice.Pair)
                            {
                                Global._shortOrderParam.TickerChoice = (Ticker)row;
                                comboTicker.SelectedItem = row;
                            }
                        }
                        
                        break;
                    }
                case LOGIC_EVENT.TICKERS_LOAD_FAILED:
                    MessageBox.Show("Balances loading failed", "error");
                    break;
                case LOGIC_EVENT.POSITIONS_SNAPSHOT:
                    {
                        lock (positionLock)
                        {
                            gridPosition.Rows.Clear();
                            object[][] positions = ((IEnumerable)param).Cast<Position>()
                                                .OrderBy(x => x.Id)
                                                .Select(x => x.ToDisplayDatas()).ToArray();
                            foreach (object[] row in positions)
                            {
                                gridPosition.Rows.Add(row);
                            }
                        }
                        break;
                    }
                case LOGIC_EVENT.POSITION_NEW:
                    {
                        lock (positionLock)
                        {
                            object[] positionData = ((Position)param).ToDisplayDatas();
                            gridPosition.Rows.Add(positionData);
                        }
                        break;
                    }
                case LOGIC_EVENT.POSITION_UPDATE:
                    {
                        lock (positionLock)
                        {
                            var position = (Position)param;
                            foreach (DataGridViewRow row in gridPosition.Rows)
                            {
                                if (Convert.ToString(row.Cells[0].Value) == position.Id)
                                {
                                    row.SetValues(position.ToDisplayDatas());
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case LOGIC_EVENT.POSITION_CANCEL:
                    {
                        lock (positionLock)
                        {
                            var position = (Position)param;
                            foreach (DataGridViewRow row in gridPosition.Rows)
                            {
                                if (Convert.ToString(row.Cells[0].Value) == position.Id)
                                {
                                    gridPosition.Rows.Remove(row);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case LOGIC_EVENT.POSITIONS_LOAD_FAILED:
                    MessageBox.Show("Positions loading failed", "error");
                    break;
                case LOGIC_EVENT.PREVIEWS_MADE:
                    textPreview.Text = "";
                    var previews = (List<string>)param;
                    if (previews.Count > 0)
                    {
                        if (previews.ElementAt(0) != "match")
                        {
                            MessageBox.Show("Count was adjusted to " + previews.ElementAt(0), "Information");
                        }
                        previews.RemoveAt(0);

                        if (previews.Count == 0)        // No order data
                        {
                            return;
                        }
                        
                        textPreview.Text = previews.ElementAt(0);
                    }
                    else
                    {
                        MessageBox.Show("Inputted data is invalid", "Error");
                        return;
                    }
                    
                    break;
                case LOGIC_EVENT.ORDERS_SNAPSHOT:
                    object[][] orders = ((IEnumerable)param).Cast<Order>()
                                            .OrderBy(x => x.Id)
                                            .Select(x => x.ToDisplayDatas())
                                        .ToArray();
                    lock (orderLock)
                    {
                        gridOrder.Rows.Clear();
                        foreach (object[] row in orders)
                        {
                            gridOrder.Rows.Add(row);
                        }
                    }
                    
                    break;
                case LOGIC_EVENT.ORDER_CANCEL:
                    {
                        Order order = ((Order)param);
                        lock (orderLock)
                        {
                            foreach (DataGridViewRow row in gridOrder.Rows)
                            {
                                if (order.Id == Convert.ToString(row.Cells[0].Value))
                                {
                                    gridOrder.Rows.Remove(row);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case LOGIC_EVENT.ORDER_UPDATE:
                    {
                        Order order = ((Order)param);
                        lock (orderLock)
                        {
                            foreach (DataGridViewRow row in gridOrder.Rows)
                            {
                                if (order.Id == Convert.ToString(row.Cells[0].Value))
                                {
                                    row.SetValues(order.ToDisplayDatas());
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case LOGIC_EVENT.ORDER_NEW:
                    object[] orderData = ((Order)param).ToDisplayDatas();
                    lock (orderLock)
                    {
                        gridOrder.Rows.Add(orderData);
                    }
                    break;
                case LOGIC_EVENT.ORDERS_LOAD_FAILED:
                    MessageBox.Show("Loading orders failed...", "Error");
                    break;
                case LOGIC_EVENT.PLACE_DONE:
                    MessageBox.Show("Bot algorithm is starting with current previewed orders.", "Information");
                    textPreview.Text = "";
                    break;
                case LOGIC_EVENT.PLACE_DONE_FAILED:
                    MessageBox.Show("No orders to place. Please click <Preview Orders> first.", "Error");
                    break;
            }
            UpdateBtnStatus(evt);
        }

        private void UpdateBtnStatus(LOGIC_EVENT evt)
        {
            switch (evt)
            {
                case LOGIC_EVENT.INIT_STEP:
                case LOGIC_EVENT.API_SERVER_CONNECT_FAILED:
                    btnConnect.Text = "Connect";
                    EnableBtn(btnConnect, true);
                    EnableBtn(btnExit, true);
                    txtApiPublicKey.Enabled = true;
                    txtApiSecretKey.Enabled = true;
                    EnableBtn(btnPreviewOrders, false);
                    EnableBtn(btnPlaceOrders, false);
                    EnableBtn(btnDeleteOrders, false);
                    EnableBtn(btnBreakAllLoops, false);
                    break;
                case LOGIC_EVENT.API_SERVER_CONNECTING:
                    btnConnect.Text = "Connecting...";
                    EnableBtn(btnConnect, false);
                    EnableBtn(btnExit, false);
                    txtApiPublicKey.Enabled = false;
                    txtApiSecretKey.Enabled = false;
                    break;
                case LOGIC_EVENT.API_SERVER_CONNECTED:
                    btnConnect.Text = "Disconnect";
                    EnableBtn(btnConnect, true);
                    EnableBtn(btnExit, true);
                    EnableBtn(btnPreviewOrders, true);
                    EnableBtn(btnPlaceOrders, false);
                    EnableBtn(btnDeleteOrders, true);
                    EnableBtn(btnBreakAllLoops, true);
                    break;
                case LOGIC_EVENT.API_SERVER_DISCONNECTING:
                    btnConnect.Text = "Disconnecting...";
                    EnableBtn(btnConnect, false);
                    txtApiPublicKey.Enabled = false;
                    txtApiSecretKey.Enabled = false;
                    EnableBtn(btnExit, false);
                    EnableBtn(btnPreviewOrders, false);
                    EnableBtn(btnPlaceOrders, false);
                    EnableBtn(btnDeleteOrders, false);
                    EnableBtn(btnBreakAllLoops, false);
                    break;
                case LOGIC_EVENT.API_SERVER_DISCONNECTED:
                    btnConnect.Text = "Connect";
                    EnableBtn(btnConnect, true);
                    txtApiPublicKey.Enabled = true;
                    txtApiSecretKey.Enabled = true;
                    EnableBtn(btnExit, true);
                    break;
                case LOGIC_EVENT.PREVIEWS_MADE:
                    EnableBtn(btnPlaceOrders, true);
                    break;
                case LOGIC_EVENT.PLACE_DONE:
                    EnableBtn(btnPlaceOrders, false);
                    break;
                case LOGIC_EVENT.EXIT_APP:
                    this.Close();
                    break;
            }
        }

        private void EnableBtn(Button btn, bool status)
        {
            btn.Enabled = status;
            if (status)
            {
                btn.BackColor = Color.FromArgb(192, 192, 255);
            } else
            {
                btn.BackColor = Color.Gray;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            UIEvent handler = UIEventListener;
            if (handler != null)
            {
                if (btnConnect.Text == "Connect")
                {
                    string publicKey = txtApiPublicKey.Text;
                    string secretKey = txtApiSecretKey.Text;
                    if (string.IsNullOrEmpty(publicKey) || string.IsNullOrEmpty(secretKey))
                    {
                        MessageBox.Show("Please input api key");
                        return;
                    }
                    handler(UI_EVENT.CONNECT_CLICK, new string[] { publicKey, secretKey });
                } else
                {
                    handler(UI_EVENT.DISCONNECT_CLICK, e);
                }
                
            }
        }

        private void btnPreviewOrders_Click(object sender, EventArgs e)
        {
            var handler = UIEventListener;
            if (handler != null)
            {
                ShortOrderParam shortOrderParam = new ShortOrderParam
                {
                    TickerChoice = new Ticker() { Pair = Convert.ToString(comboTicker.SelectedItem) },
                    DistributionType = (DISTRIBUTION_TYPE)comboDistribution.SelectedIndex,
                    LowerPrice = (double)spinLowerPrice.Value,
                    UpperPrice = (double)spinUpperPrice.Value,
                    Coefficient = (double)spinCoefficient.Value,
                    MinSize = (double)spinMinSize.Value,
                    Amount = (double)spinAmount.Value,
                    OrderCount = (int)spinOrderCount.Value
                };

                handler(UI_EVENT.PREVIEW_CLICK, shortOrderParam);
            }
        }

        private void btnPlaceOrders_Click(object sender, EventArgs e)
        {
            var handler = UIEventListener;
            if (handler != null)
            {
                ConditionalOrderParam condOrderParam = new ConditionalOrderParam
                {
                    ProfitTarget = (double)spinProfitTarget.Value,
                    ProfitPercent = (double)spinProfitPercent.Value,
                    Distance = (double)spinDistance.Value,
                    Fee = (double)spinFee.Value,
                    TargetOrPercent = radioProfitTarget.Checked
                };
                handler(UI_EVENT.PLACE_CLICK, condOrderParam);
            }
        }

        private void btnDeleteOrders_Click(object sender, EventArgs e)
        {
            var handler = UIEventListener;
            if (handler != null)
            {
                handler(UI_EVENT.DELETE_CLICK, true);
            }
        }

        private void btnBreakAllLoops_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            UIEvent handler = UIEventListener;
            if (handler != null)
            {
                handler(UI_EVENT.EXIT_CLICK, this);
            }
        }
    }
}
