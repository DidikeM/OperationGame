
namespace Game.Forms
{
    partial class LaunchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDefault = new System.Windows.Forms.Button();
            this.btnAdvenced = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDefault
            // 
            this.btnDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDefault.Location = new System.Drawing.Point(50, 50);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(200, 75);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.Text = "Sıradan";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // btnAdvenced
            // 
            this.btnAdvenced.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdvenced.Location = new System.Drawing.Point(276, 50);
            this.btnAdvenced.Name = "btnAdvenced";
            this.btnAdvenced.Size = new System.Drawing.Size(200, 75);
            this.btnAdvenced.TabIndex = 1;
            this.btnAdvenced.Text = "Gelişmiş";
            this.btnAdvenced.UseVisualStyleBackColor = true;
            this.btnAdvenced.Click += new System.EventHandler(this.btnAdvenced_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(46, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 120);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bu oyun modunda bütün \r\nsayıları kullanmak zorunda \r\ndeğilsinizdir.\r\nCevap rastge" +
    "le üretildiği \r\niçin sonuca tam \r\nulaşamıyabilirsiniz!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(272, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 120);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bu oyun modunda bütün \r\nsayıları kullanmak \r\nzorundasınızdır.\r\nCevap rastgele değ" +
    "ildir! \r\nHer sorunun kesin cevabı\r\n vardır.";
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 325);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdvenced);
            this.Controls.Add(this.btnDefault);
            this.Name = "LaunchForm";
            this.Text = "LaunchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Button btnAdvenced;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}