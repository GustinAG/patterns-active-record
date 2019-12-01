using System.Text;
using System.Windows.Forms;
using ActiveRecord.BusinessLogic;
using ActiveRecord.CheckOut.Contracts;

namespace ActiveRecord.CheckOutGUI
{
    /// <inheritdoc />
    /// <summary>
    /// The check-out form.
    /// </summary>
    public partial class CheckOutForm : Form
    {
        private readonly CheckOutServices _services = new CheckOutServices();

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckOutForm"/> class.
        /// </summary>
        public CheckOutForm()
        {
            InitializeComponent();
        }

        #region Static helpers
        private static string GenerateSummaryText(IBill bill)
        {
            var builder = new StringBuilder();

            foreach (IProduct product in bill.Products)
                builder.AppendLine($"{product.Count,2} {product.Name,-15} €{product.UnitPrice,5:f2}  €{product.TotalPrice,5:f2}");

            builder.AppendLine("-----------------------------------------");
            builder.AppendLine($"{"  TOTAL",-26} €{bill.TotalPrice,5:f2}");

            return builder.ToString();
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the StartButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void StartButtonClick(object sender, System.EventArgs e)
        {
            EnableCheckOutControls(true);
            CodeNumericUpDown.Focus();

            _services.Start();
        }

        /// <summary>
        /// Handles the Click event of the ScanButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ScanButtonClick(object sender, System.EventArgs e)
        {
            _services.Scan((long)CodeNumericUpDown.Value);

            CodeNumericUpDown.Value = 0;
            CodeNumericUpDown.Focus();
        }

        /// <summary>
        /// Handles the Click event of the CloseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CloseButtonClick(object sender, System.EventArgs e)
        {
            IBill bill = _services.CurrentBill;

            EnableCheckOutControls(false);
            Display(bill);
        }

        #region Helpers
        private void EnableCheckOutControls(bool enable)
        {
            StartButton.Enabled = !enable;
            CodeNumericUpDown.Enabled = ScanButton.Enabled = CloseButton.Enabled = enable;
            if (enable) SummaryTextBox.Text = string.Empty;
        }

        private void Display(IBill bill) => SummaryTextBox.Text = GenerateSummaryText(bill);
        #endregion
    }
}
