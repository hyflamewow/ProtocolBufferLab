namespace Lab02
{
    partial class frmMain
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSerialize = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnParseSpeed = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSerialize
            // 
            this.btnSerialize.Location = new System.Drawing.Point(63, 37);
            this.btnSerialize.Name = "btnSerialize";
            this.btnSerialize.Size = new System.Drawing.Size(188, 81);
            this.btnSerialize.TabIndex = 0;
            this.btnSerialize.Text = "Serialize";
            this.btnSerialize.UseVisualStyleBackColor = true;
            this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(62, 160);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(189, 87);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnParseSpeed
            // 
            this.btnParseSpeed.Location = new System.Drawing.Point(325, 166);
            this.btnParseSpeed.Name = "btnParseSpeed";
            this.btnParseSpeed.Size = new System.Drawing.Size(148, 80);
            this.btnParseSpeed.TabIndex = 2;
            this.btnParseSpeed.Text = "Parse Speed";
            this.btnParseSpeed.UseVisualStyleBackColor = true;
            this.btnParseSpeed.Click += new System.EventHandler(this.btnParseSpeed_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 340);
            this.Controls.Add(this.btnParseSpeed);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnSerialize);
            this.Name = "frmMain";
            this.Text = "Protocol Buffer Lab02";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSerialize;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnParseSpeed;
    }
}

