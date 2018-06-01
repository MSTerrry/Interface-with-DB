namespace DW.UI
{
    partial class CabForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияОФайлеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокПользователейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderControl = new System.Windows.Forms.TabControl();
            this.NewOrders = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.OldOrders = new System.Windows.Forms.TabPage();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.NewOrder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.DeleteOrderButton = new System.Windows.Forms.Button();
            this.экспортЗаказаВWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.OrderControl.SuspendLayout();
            this.NewOrders.SuspendLayout();
            this.OldOrders.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem1,
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem1
            // 
            this.файлToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортЗаказаВWordToolStripMenuItem,
            this.информацияОФайлеToolStripMenuItem,
            this.выходToolStripMenuItem1});
            this.файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            this.файлToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem1.Text = "Файл";
            // 
            // информацияОФайлеToolStripMenuItem
            // 
            this.информацияОФайлеToolStripMenuItem.Name = "информацияОФайлеToolStripMenuItem";
            this.информацияОФайлеToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.информацияОФайлеToolStripMenuItem.Text = "Информация о файле";
            this.информацияОФайлеToolStripMenuItem.Click += new System.EventHandler(this.информацияОФайлеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem1
            // 
            this.выходToolStripMenuItem1.Name = "выходToolStripMenuItem1";
            this.выходToolStripMenuItem1.Size = new System.Drawing.Size(197, 22);
            this.выходToolStripMenuItem1.Text = "Выход";
            this.выходToolStripMenuItem1.Click += new System.EventHandler(this.выходToolStripMenuItem1_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокПользователейToolStripMenuItem,
            this.открытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.файлToolStripMenuItem.Text = "Пользователь";
            // 
            // списокПользователейToolStripMenuItem
            // 
            this.списокПользователейToolStripMenuItem.Name = "списокПользователейToolStripMenuItem";
            this.списокПользователейToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.списокПользователейToolStripMenuItem.Text = "Список пользователей";
            this.списокПользователейToolStripMenuItem.Click += new System.EventHandler(this.списокПользователейToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.открытьToolStripMenuItem.Text = "Сменить пользователя";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // OrderControl
            // 
            this.OrderControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrderControl.Controls.Add(this.NewOrders);
            this.OrderControl.Controls.Add(this.OldOrders);
            this.OrderControl.Location = new System.Drawing.Point(13, 28);
            this.OrderControl.Name = "OrderControl";
            this.OrderControl.SelectedIndex = 0;
            this.OrderControl.Size = new System.Drawing.Size(692, 326);
            this.OrderControl.TabIndex = 1;
            // 
            // NewOrders
            // 
            this.NewOrders.Controls.Add(this.listBox1);
            this.NewOrders.Location = new System.Drawing.Point(4, 22);
            this.NewOrders.Name = "NewOrders";
            this.NewOrders.Padding = new System.Windows.Forms.Padding(3);
            this.NewOrders.Size = new System.Drawing.Size(684, 300);
            this.NewOrders.TabIndex = 0;
            this.NewOrders.Text = "Текущие заказы";
            this.NewOrders.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(681, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // OldOrders
            // 
            this.OldOrders.Controls.Add(this.listBox2);
            this.OldOrders.Location = new System.Drawing.Point(4, 22);
            this.OldOrders.Name = "OldOrders";
            this.OldOrders.Padding = new System.Windows.Forms.Padding(3);
            this.OldOrders.Size = new System.Drawing.Size(684, 300);
            this.OldOrders.TabIndex = 1;
            this.OldOrders.Text = "Предыдущие заказы";
            this.OldOrders.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 0);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(684, 303);
            this.listBox2.TabIndex = 0;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Location = new System.Drawing.Point(594, 360);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(104, 23);
            this.RefreshButton.TabIndex = 2;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // NewOrder
            // 
            this.NewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewOrder.Location = new System.Drawing.Point(17, 360);
            this.NewOrder.Name = "NewOrder";
            this.NewOrder.Size = new System.Drawing.Size(102, 23);
            this.NewOrder.TabIndex = 3;
            this.NewOrder.Text = "Новый заказ";
            this.NewOrder.UseVisualStyleBackColor = true;
            this.NewOrder.Click += new System.EventHandler(this.NewOrder_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(717, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBar
            // 
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(97, 17);
            this.StatusBar.Text = "You logged in as:";
            // 
            // DeleteOrderButton
            // 
            this.DeleteOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteOrderButton.Location = new System.Drawing.Point(125, 360);
            this.DeleteOrderButton.Name = "DeleteOrderButton";
            this.DeleteOrderButton.Size = new System.Drawing.Size(102, 23);
            this.DeleteOrderButton.TabIndex = 5;
            this.DeleteOrderButton.Text = "Удалить заказ";
            this.DeleteOrderButton.UseVisualStyleBackColor = true;
            this.DeleteOrderButton.Visible = false;
            this.DeleteOrderButton.Click += new System.EventHandler(this.DeleteOrderButton_Click);
            // 
            // экспортЗаказаВWordToolStripMenuItem
            // 
            this.экспортЗаказаВWordToolStripMenuItem.Name = "экспортЗаказаВWordToolStripMenuItem";
            this.экспортЗаказаВWordToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.экспортЗаказаВWordToolStripMenuItem.Text = "Экспорт заказа в Word";
            this.экспортЗаказаВWordToolStripMenuItem.Click += new System.EventHandler(this.экспортЗаказаВWordToolStripMenuItem_Click);
            // 
            // CabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 414);
            this.Controls.Add(this.DeleteOrderButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.NewOrder);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.OrderControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CabForm";
            this.Text = "Личный кабинет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CabForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.OrderControl.ResumeLayout(false);
            this.NewOrders.ResumeLayout(false);
            this.OldOrders.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.TabControl OrderControl;
        private System.Windows.Forms.TabPage NewOrders;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage OldOrders;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button NewOrder;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar;
        private System.Windows.Forms.ToolStripMenuItem списокПользователейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem информацияОФайлеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem1;
        private System.Windows.Forms.Button DeleteOrderButton;
        private System.Windows.Forms.ToolStripMenuItem экспортЗаказаВWordToolStripMenuItem;
    }
}