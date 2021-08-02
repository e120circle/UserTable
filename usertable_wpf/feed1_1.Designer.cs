namespace usertable_wpf
{
    partial class feed1_1
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.userControl11 = new View.feed1_1(NCLinker2);
            this.SuspendLayout();
            // 
            // elementHost1
            // 
            this.elementHost1.AutoSize = false;
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(199, 95);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.userControl11;
            // 
            // feed1_1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.AutoSize = false;
            this.Controls.Add(this.elementHost1);
            this.Name = "feed1_1";
            this.Size = new System.Drawing.Size(199, 95);
            this.ResumeLayout(false);       

        }

        #endregion
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private usertable_wpf.View.feed1_1 userControl11;
    }
}
