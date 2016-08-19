using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCOM3Lib;
using System.Runtime.InteropServices;
using System.IO;

namespace MarkTCOM {
    class SmartComConnect {

        private static string login = "AO28KF31";
        private static string password = "H44928";
        private static string file_path = "logs/logi.txt";
        //private SQLite sql;
        //private Model.Glass glass;
        string symbol = "RTS-9.16_FT";
        //string symbol = "SBER";
        //string portfolio = "ST80569-RF-01";



        StServer mSmartCOMInstance;

        public SmartComConnect() {
            try {

                //using (StreamWriter file = new StreamWriter(file_path)) {
                //    file.Close();
                //}

                //sql = new SQLite();
                //sql.Open();

                mSmartCOMInstance = new StServerClass();

                mSmartCOMInstance.ConfigureClient("logLevel=5;");

                mSmartCOMInstance.AddBar += new _IStClient_AddBarEventHandler(mSmartCOMInstance_AddBar);
                mSmartCOMInstance.AddPortfolio += new _IStClient_AddPortfolioEventHandler(mSmartCOMInstanc_AddPortfolio);
                mSmartCOMInstance.AddSymbol += new _IStClient_AddSymbolEventHandler(mSmartCOMInstanc_AddSymbol);
                mSmartCOMInstance.AddTick += new _IStClient_AddTickEventHandler(mSmartCOMInstance_AddTick);
                mSmartCOMInstance.AddTickHistory += new _IStClient_AddTickHistoryEventHandler(SmartServer_AddTickHistory);
                mSmartCOMInstance.AddTrade += new _IStClient_AddTradeEventHandler(mSmartCOMInstanc_AddTrade);
                mSmartCOMInstance.Connected += new _IStClient_ConnectedEventHandler(mSmartCOMInstance_Connected);
                mSmartCOMInstance.Disconnected += new _IStClient_DisconnectedEventHandler(mSmartCOMInstance_Disconnected);
                mSmartCOMInstance.OrderCancelFailed += new _IStClient_OrderCancelFailedEventHandler(mSmartCOMInstance_OrderCancelFailed);
                mSmartCOMInstance.OrderCancelSucceeded += new _IStClient_OrderCancelSucceededEventHandler(OrderCancelSucceeded);
                mSmartCOMInstance.OrderMoveFailed += new _IStClient_OrderMoveFailedEventHandler(mSmartCOMInstance_OrderMoveFailed);
                mSmartCOMInstance.OrderMoveSucceeded += new _IStClient_OrderMoveSucceededEventHandler(mSmartCOMInstance_OrderMoveSucceeded);
                mSmartCOMInstance.OrderFailed += new _IStClient_OrderFailedEventHandler(mSmartCOMInstance_OrderFailed);
                mSmartCOMInstance.OrderSucceeded += new _IStClient_OrderSucceededEventHandler(mSmartCOMInstance_OrderSucceeded);
                mSmartCOMInstance.SetMyClosePos += new _IStClient_SetMyClosePosEventHandler(mSmartCOMInstanc_SetMyClosePos);
                mSmartCOMInstance.SetMyOrder += new _IStClient_SetMyOrderEventHandler(mSmartCOMInstance_SetMyOrder);
                mSmartCOMInstance.SetMyTrade += new _IStClient_SetMyTradeEventHandler(mSmartCOMInstanc_SetMyTrade);
                mSmartCOMInstance.SetPortfolio += new _IStClient_SetPortfolioEventHandler(mSmartCOMInstance_SetPortfolio);
                mSmartCOMInstance.UpdateBidAsk += new _IStClient_UpdateBidAskEventHandler(mSmartCOMInstance_UpdateBidAsk);
                mSmartCOMInstance.UpdatePosition += new _IStClient_UpdatePositionEventHandler(mSmartCOMInstanc_UpdatePosition);
                mSmartCOMInstance.UpdateOrder += new _IStClient_UpdateOrderEventHandler(mSmartCOMInstance_UpdateOrder);
                mSmartCOMInstance.UpdateQuote += new _IStClient_UpdateQuoteEventHandler(mSmartCOMInstance_UpdateQuote);


                //Model.Bar bar = new Model.Bar("SBER", StBarInterval.StBarInterval_10Min, 10, 654, 654, 465, 435, 654, 465);



            }
            catch (COMException e) {

                Console.WriteLine("свалилсь " + e);
                Console.ReadKey();

            }
            catch (Exception e) {
                Console.WriteLine("свалилсь " + e);
                Console.ReadKey();

            }
        }

        public void Run() {
            try {

                mSmartCOMInstance.connect("mxdemo.ittrade.ru", 8443, login, password);

                while (!mSmartCOMInstance.IsConnected()) ;


                //Console.ReadKey();

                //mSmartCOMInstance.PlaceOrder(portfolio, symbol, StOrder_Action.StOrder_Action_Buy, StOrder_Type.StOrder_Type_Market, StOrder_Validity.StOrder_Validity_Day, 0, 1, 0, 555);
                //Console.ReadKey();
                //mSmartCOMInstance.PlaceOrder(portfolio, symbol, StOrder_Action.StOrder_Action_Sell, StOrder_Type.StOrder_Type_Market, StOrder_Validity.StOrder_Validity_Day, 0, 1, 0, 666);


                //mSmartCOMInstance.ListenBidAsks(symbol);

                //Console.ReadKey();

                //mSmartCOMInstance.ListenQuotes(symbol);

                //Console.ReadKey();

                //mSmartCOMInstance.ListenTicks(symbol);

                Console.ReadKey();

                //mSmartCOMInstance.GetBars(symbol, StBarInterval.StBarInterval_1Min, DateTime.Now, 20);
                //mSmartCOMInstance.GetSymbols();
                //mSmartCOMInstance.GetPrortfolioList();

                //Console.WriteLine(new DateTime(2016, 8, 16, 21,44, 00));

                //mSmartCOMInstance.GetTrades(symbol, new DateTime(2016, 8, 16, 13, 44, 00), 10);
                Console.ReadKey();


                mSmartCOMInstance.disconnect();

                Console.ReadKey();

            }
            catch (COMException e) {
                Console.WriteLine("свалилсь " + e);
                Console.ReadKey();
            }
            catch (Exception e) {
                Console.WriteLine("свалилсь " + e);
                Console.ReadKey();

            }
            finally {
                //sql.Close();
            }
        }

        void mSmartCOMInstance_Connected() {

            mSmartCOMInstance.ListenBidAsks(symbol);
            // mSmartCOMInstance.ListenQuotes(symbol);
            //mSmartCOMInstance.ListenTicks(symbol);
            //mSmartCOMInstance.ListenPortfolio(portfolio);
        }

        private void mSmartCOMInstanc_SetMyTrade(int row, int nrows, string portfolio, string symbol, DateTime datetime, double price, double volume, string tradeno, StOrder_Action buysell, string orderno) {
            Console.WriteLine("Сработал метод SetMyTrade");
        }

        private void mSmartCOMInstanc_SetMyClosePos(int row, int nrows, string portfolio, string symbol, double amount, double price_buy, double price_sell, DateTime postime, string order_open, string order_close) {
            Console.WriteLine("Сработал метод SetMyClosePos");
        }

        private void mSmartCOMInstance_OrderSucceeded(int cookie, string orderid) {
            Console.WriteLine("Сработал метод OrderSucceeded");
        }

        private void mSmartCOMInstance_OrderFailed(int cookie, string orderid, string reason) {
            Console.WriteLine("Сработал метод OrderFailed");
        }

        private void mSmartCOMInstance_OrderMoveSucceeded(string orderid) {
            Console.WriteLine("Сработал метод OrderMoveSucceeded");
        }

        private void mSmartCOMInstance_OrderMoveFailed(string orderid) {
            Console.WriteLine("Сработал метод OrderMoveFailed");
        }

        private void OrderCancelSucceeded(string orderid) {
            Console.WriteLine("Сработал метод OrderCancelSucceeded");
        }

        private void mSmartCOMInstance_OrderCancelFailed(string orderid) {
            Console.WriteLine("Сработал метод OrderCancelFailed");
        }

        private void mSmartCOMInstance_SetMyOrder(int row, int nrows, string portfolio, string symbol, StOrder_State state, StOrder_Action action, StOrder_Type type, StOrder_Validity validity, double price, double amount, double stop, double filled, DateTime datetime, string id, string no, int cookie) {
            Console.WriteLine("mSmartCOMInstance_SetMyOrder:");
        }

        private void mSmartCOMInstance_SetPortfolio(string portfolio, double cash, double leverage, double comission, double saldo) {
            Console.WriteLine("mSmartCOMInstance_SetPortfolio:");
        }

        private void mSmartCOMInstance_Disconnected(string reason) {
            Console.WriteLine("mSmartCOMInstance_Disconnected reason " + reason);
        }

        private void mSmartCOMInstance_AddBar(int row, int nrows, string symbol, StBarInterval interval, DateTime datetime, double open, double high, double low, double close, double volume, double open_int) {
            string str = "AddBar: row=" + row + ", nrows=" + nrows + ", symbol=" + symbol + ", interval=" + interval + ", datetime=" + ", " + datetime + ", open=" + open + ", high=" + high + ", low=" + low + ", close=" + close + ", volume=" + volume + ", open_int=" + open_int;

            using (StreamWriter file = new StreamWriter(file_path, true)) {
                file.WriteLine(str);
            }

            //Model.Bar bar = new Model.Bar(symbol, interval, Helper.getDateTimeInSeconds(datetime), open, close, high, low, volume, open_int);

            //bar.InsertBar(sql);

            Console.WriteLine(str);
            //Console.WriteLine("AddBar row ={0}, nrows={1}, symbol={2}, interval={3}, datetime={4}, open={5}, high={6}, low={7}, close={8}, volume={9}, open_int={10}", row, nrows, symbol, interval, datetime, open, high, low, close, volume, open_int);
        }

        private void SmartServer_AddTickHistory(int row, int nrows, string symbol, DateTime datetime, double price, double volume, string tradeno, StOrder_Action action) {
            string str = "AddTickHistory: row=" + row + ", nrows=" + nrows + "symbol=" + symbol + ", datetime=" + datetime + ", price=" + price + ", volume=" + volume + ", tradeno=" + tradeno + ", action=" + action;
            using (StreamWriter file = new StreamWriter("logs/AddTickHistory.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstance_AddTick(string symbol, DateTime datetime, double price, double volume, string tradeno, StOrder_Action action) {
            string str = "AddTick: symbol=" + symbol + ", datetime" + datetime + ", price=" + price + ", volume=" + volume + ", tradeno=" + tradeno + ", action=" + action;
            using (StreamWriter file = new StreamWriter("logs/AddTick.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);
        }

        private void mSmartCOMInstanc_AddSymbol(int row, int nrows, string symbol, string short_name, string long_name, string type, int decimals, int lot_size, double punkt, double step, string sec_ext_id, string sec_exch_name, DateTime expiry_date, double days_before_expiry, double strike) {
            string str = "AddSymbol: row=" + row +
                                  ", nrow=" + nrows +
                                  ", symbol=" + symbol +
                                  ", short_name=" + short_name +
                                  ", long_name=" + long_name +
                                  ", type=" + type +
                                  ", decimals=" + decimals +
                                  ", lot_size=" + lot_size +
                                  ", step=" + step +
                                  ", sec_exch_name=" + sec_exch_name +
                                  ", expiry_date=" + expiry_date +
                                  ", days_before_expiry=" + days_before_expiry +
                                  ", strike" + strike;
            using (StreamWriter file = new StreamWriter("logs/AddSymbol.txt", true)) {
                file.WriteLine(str);
            }
        }

        private void mSmartCOMInstanc_AddTrade(string portfolio, string symbol, string orderid, double price, double amount, DateTime datetime, string tradeno) {
            string str = "AddTrade: portfolio=" + portfolio + ", symbol=" + symbol + ", orderid=" + orderid + ", price=" + price + ", amount=" + amount + ", datetime=" + datetime + ", tradeno=" + tradeno;
            using (StreamWriter file = new StreamWriter("logs/AddTrade.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstanc_UpdatePosition(string portfolio, string symbol, double avprice, double amount, double planned) {
            string str = "UpdatePosition: portfolio=" + portfolio + ", symbol=" + symbol + ", avprice=" + avprice + ", amount=" + amount + ", planned=" + planned;
            using (StreamWriter file = new StreamWriter("logs/UpdatePosition.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstanc_SetPortfolio(string portfolio, double cash, double leverage, double comission, double saldo) {

            string str = "SetPortfolio: portfolio=" + portfolio + ", cash=" + cash + ", leverage=" + leverage + ", commission=" + comission + ", saldo=" + saldo;
            using (StreamWriter file = new StreamWriter("logs/SetPortfolio.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstance_UpdateOrder(string portfolio, string symbol, StOrder_State state, StOrder_Action action, StOrder_Type type, StOrder_Validity validity, double price, double amount, double stop, double filled, DateTime datetime, string orderid, string orderno, int status_mask, int cookie) {
            Console.WriteLine("Сработал метод UpdateOrder");
        }

        private void mSmartCOMInstanc_AddPortfolio(int row, int nrows, string portfolioName, string portfolioExch, StPortfolioStatus portfolioStatus) {
            string str = "AddPortfolio: row+=" + row + ",nrows=" + nrows + ", portfolioName=" + portfolioName + ", portfolioExch=" + portfolioExch + ", portfolioStatus=" + portfolioStatus;
            using (StreamWriter file = new StreamWriter("logs/AddPortfolio.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstance_UpdateQuote(string symbol, DateTime datetime, double open, double high, double low, double close, double last, double volume, double size, double bid, double ask, double bidsize, double asksize, double open_int, double go_buy, double go_sell, double go_base, double go_base_backed, double high_limit, double low_limit, int trading_status, double volat, double theor_price) {
            string str = "UpdateQuote: symbol=" + symbol + "datetime=" + datetime + ", open=" + open + ", high=" + high + ", low=" + low + ", close=" + close + ", last=" + last + ", volume=" + volume + ", size=" + size + ", bid=" + bid + ", ask=" + ask + ", bidsize=" + bidsize + ", asksize=" + asksize + ", open_int=" + open_int + ", gp_buy=" + go_buy + ", go_sell=" + go_sell + ", go_base=" + go_base + ", go_base_backed=" + go_base_backed + ", high_limit=" + high_limit + ", low_limit=" + low_limit + ", trading_status=" + trading_status + ", volat=" + volat + ", theor_price=" + theor_price;

            using (StreamWriter file = new StreamWriter("logs/UpdateQuote.txt", true)) {
                file.WriteLine(str);
            }
            Console.WriteLine(str);

        }

        private void mSmartCOMInstance_UpdateBidAsk(string symbol, int row, int nrows, double bid, double bidsize, double ask, double asksize) {
            string str = "UpdateBidAsk: symbol=" + symbol + ", row=" + row + ", nrows=" + nrows + ", bid=" + bid + ", bidsize=" + bidsize + ", ask=" + ask + ", asksize=" + asksize;

            //if (row == 0) {
            //    glass = new Model.Glass();
            //    glass.add(new Model.GlassPairOrder(symbol, row, nrows, bid, bidsize, ask, asksize));
            //} else if (row < 20) {
            //    glass.add(new Model.GlassPairOrder(symbol, row, nrows, bid, bidsize, ask, asksize));
            //} else if (row == 20) {
            //    Console.Clear();
            //    Console.WriteLine("Кол-во заявок: " + 20 + ", Сумарный объем: " + glass.getDirection());
            //    glass.getDirection();
            //}
            //using (StreamWriter file = new StreamWriter("logs/UpdateBidAsk.txt", true)) {
            //    file.WriteLine(str);
            //}
            Console.WriteLine(str);

        }

    }
}
