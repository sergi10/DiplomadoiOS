using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace PhoneApp
{
    public partial class ClassHistoryController : UITableViewController
    {

        public List<string> PhoneNumbers { get; set; }
        protected NSString CallHistoryCellID = new NSString("CallHistoryCell");
        public ClassHistoryController(IntPtr handle) : base(handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell), CallHistoryCellID);
            TableView.Source = new CallHistoryDataSource(this);
        }
        class CallHistoryDataSource : UITableViewSource
        {
            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var Cell = tableView.DequeueReusableCell(Controller.CallHistoryCellID);
                Cell.TextLabel.Text = Controller.PhoneNumbers[indexPath.Row];
                return Cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return Controller.PhoneNumbers.Count;
            }

            ClassHistoryController Controller;
            public CallHistoryDataSource(ClassHistoryController controller)
            {
                this.Controller = controller;
            }
        }
    }
}