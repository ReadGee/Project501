namespace DvorecKulturi
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BuyOnEvent_btn = new System.Windows.Forms.Button();
            this.ClearSearch_btn = new System.Windows.Forms.Button();
            this.Search_btn = new System.Windows.Forms.Button();
            this.Search_textbox = new System.Windows.Forms.TextBox();
            this.UserEvent_dataGrid = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BuyTickets_btn = new System.Windows.Forms.Button();
            this.LabelForSumma_text = new System.Windows.Forms.Label();
            this.Phone_textbox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FioOnNew_textbox = new System.Windows.Forms.TextBox();
            this.UserTickets_datagrid = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.LogoText = new System.Windows.Forms.Label();
            this.SingIn_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserEvent_dataGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserTickets_datagrid)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tabControl1.ItemSize = new System.Drawing.Size(10, 10);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1097, 594);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BuyOnEvent_btn);
            this.tabPage1.Controls.Add(this.ClearSearch_btn);
            this.tabPage1.Controls.Add(this.Search_btn);
            this.tabPage1.Controls.Add(this.Search_textbox);
            this.tabPage1.Controls.Add(this.UserEvent_dataGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 14);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1089, 576);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // BuyOnEvent_btn
            // 
            this.BuyOnEvent_btn.Location = new System.Drawing.Point(507, 513);
            this.BuyOnEvent_btn.Name = "BuyOnEvent_btn";
            this.BuyOnEvent_btn.Size = new System.Drawing.Size(129, 41);
            this.BuyOnEvent_btn.TabIndex = 4;
            this.BuyOnEvent_btn.Text = "Подробнее";
            this.BuyOnEvent_btn.UseVisualStyleBackColor = true;
            this.BuyOnEvent_btn.Click += new System.EventHandler(this.BuyOnEvent_btn_Click);
            // 
            // ClearSearch_btn
            // 
            this.ClearSearch_btn.Location = new System.Drawing.Point(735, 76);
            this.ClearSearch_btn.Name = "ClearSearch_btn";
            this.ClearSearch_btn.Size = new System.Drawing.Size(75, 23);
            this.ClearSearch_btn.TabIndex = 3;
            this.ClearSearch_btn.Text = "Очистить";
            this.ClearSearch_btn.UseVisualStyleBackColor = true;
            this.ClearSearch_btn.Click += new System.EventHandler(this.ClearSearch_btn_Click);
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(654, 76);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 23);
            this.Search_btn.TabIndex = 2;
            this.Search_btn.Text = "Поиск";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_event);
            // 
            // Search_textbox
            // 
            this.Search_textbox.Location = new System.Drawing.Point(330, 78);
            this.Search_textbox.Name = "Search_textbox";
            this.Search_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Search_textbox.Size = new System.Drawing.Size(306, 20);
            this.Search_textbox.TabIndex = 1;
            this.Search_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserEvent_dataGrid
            // 
            this.UserEvent_dataGrid.AllowUserToAddRows = false;
            this.UserEvent_dataGrid.AllowUserToDeleteRows = false;
            this.UserEvent_dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserEvent_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserEvent_dataGrid.Location = new System.Drawing.Point(0, 120);
            this.UserEvent_dataGrid.Name = "UserEvent_dataGrid";
            this.UserEvent_dataGrid.ReadOnly = true;
            this.UserEvent_dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserEvent_dataGrid.Size = new System.Drawing.Size(1089, 381);
            this.UserEvent_dataGrid.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.BuyTickets_btn);
            this.tabPage2.Controls.Add(this.LabelForSumma_text);
            this.tabPage2.Controls.Add(this.Phone_textbox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.FioOnNew_textbox);
            this.tabPage2.Controls.Add(this.UserTickets_datagrid);
            this.tabPage2.Location = new System.Drawing.Point(4, 14);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1089, 576);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BuyTickets_btn
            // 
            this.BuyTickets_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BuyTickets_btn.Location = new System.Drawing.Point(871, 249);
            this.BuyTickets_btn.Name = "BuyTickets_btn";
            this.BuyTickets_btn.Size = new System.Drawing.Size(118, 39);
            this.BuyTickets_btn.TabIndex = 7;
            this.BuyTickets_btn.Text = "Оплатить";
            this.BuyTickets_btn.UseVisualStyleBackColor = true;
            this.BuyTickets_btn.Click += new System.EventHandler(this.BuyTickets_btn_Click);
            // 
            // LabelForSumma_text
            // 
            this.LabelForSumma_text.AutoSize = true;
            this.LabelForSumma_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LabelForSumma_text.Location = new System.Drawing.Point(857, 183);
            this.LabelForSumma_text.Name = "LabelForSumma_text";
            this.LabelForSumma_text.Size = new System.Drawing.Size(120, 17);
            this.LabelForSumma_text.TabIndex = 6;
            this.LabelForSumma_text.Text = "Сумма к оплате: ";
            // 
            // Phone_textbox
            // 
            this.Phone_textbox.Location = new System.Drawing.Point(860, 68);
            this.Phone_textbox.Mask = "+7 (999) 999-99-99";
            this.Phone_textbox.Name = "Phone_textbox";
            this.Phone_textbox.Size = new System.Drawing.Size(223, 20);
            this.Phone_textbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(758, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер телефона:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(817, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ФИО:";
            // 
            // FioOnNew_textbox
            // 
            this.FioOnNew_textbox.Location = new System.Drawing.Point(860, 29);
            this.FioOnNew_textbox.Name = "FioOnNew_textbox";
            this.FioOnNew_textbox.Size = new System.Drawing.Size(223, 20);
            this.FioOnNew_textbox.TabIndex = 1;
            // 
            // UserTickets_datagrid
            // 
            this.UserTickets_datagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UserTickets_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UserTickets_datagrid.Location = new System.Drawing.Point(6, 32);
            this.UserTickets_datagrid.Name = "UserTickets_datagrid";
            this.UserTickets_datagrid.ReadOnly = true;
            this.UserTickets_datagrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UserTickets_datagrid.Size = new System.Drawing.Size(742, 530);
            this.UserTickets_datagrid.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 14);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1089, 576);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(310, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(455, 40);
            this.label4.TabIndex = 0;
            this.label4.Text = "Спасибо за покупку!\r\nС вами свяжеться наш менеджер для уточнения деталей.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogoText
            // 
            this.LogoText.AutoSize = true;
            this.LogoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.LogoText.Location = new System.Drawing.Point(12, 9);
            this.LogoText.Name = "LogoText";
            this.LogoText.Size = new System.Drawing.Size(127, 22);
            this.LogoText.TabIndex = 1;
            this.LogoText.Text = "ДК \"Химиков\"";
            // 
            // SingIn_btn
            // 
            this.SingIn_btn.Location = new System.Drawing.Point(1030, 17);
            this.SingIn_btn.Name = "SingIn_btn";
            this.SingIn_btn.Size = new System.Drawing.Size(75, 23);
            this.SingIn_btn.TabIndex = 2;
            this.SingIn_btn.Text = "Вход";
            this.SingIn_btn.UseVisualStyleBackColor = true;
            this.SingIn_btn.Click += new System.EventHandler(this.SingIn_btn_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Назад";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(6, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Назад";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 647);
            this.Controls.Add(this.SingIn_btn);
            this.Controls.Add(this.LogoText);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "ДК \"Химиков\" - Мероприятие";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserEvent_dataGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserTickets_datagrid)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox Search_textbox;
        private System.Windows.Forms.DataGridView UserEvent_dataGrid;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button BuyOnEvent_btn;
        private System.Windows.Forms.Button ClearSearch_btn;
        private System.Windows.Forms.Label LogoText;
        private System.Windows.Forms.TextBox FioOnNew_textbox;
        private System.Windows.Forms.DataGridView UserTickets_datagrid;
        private System.Windows.Forms.MaskedTextBox Phone_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BuyTickets_btn;
        private System.Windows.Forms.Label LabelForSumma_text;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SingIn_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}

