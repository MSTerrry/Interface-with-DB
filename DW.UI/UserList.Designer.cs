namespace DW.UI
{
    partial class UserList
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
            this.GridUserList = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Savebutton = new System.Windows.Forms.Button();
            this.ExportBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // GridUserList
            // 
            this.GridUserList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridUserList.Location = new System.Drawing.Point(12, 12);
            this.GridUserList.Name = "GridUserList";
            this.GridUserList.Size = new System.Drawing.Size(465, 302);
            this.GridUserList.TabIndex = 0;
            this.GridUserList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridUserList_CellContentClick);
            this.GridUserList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridUserList_CellEndEdit);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(513, 51);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 44);
            this.Add.TabIndex = 1;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(513, 184);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 44);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Удалить";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Savebutton
            // 
            this.Savebutton.Location = new System.Drawing.Point(513, 117);
            this.Savebutton.Name = "Savebutton";
            this.Savebutton.Size = new System.Drawing.Size(75, 44);
            this.Savebutton.TabIndex = 3;
            this.Savebutton.Text = "Сохранить изменения";
            this.Savebutton.UseVisualStyleBackColor = true;
            this.Savebutton.Click += new System.EventHandler(this.Savebutton_Click);
            // 
            // ExportBut
            // 
            this.ExportBut.Location = new System.Drawing.Point(513, 250);
            this.ExportBut.Name = "ExportBut";
            this.ExportBut.Size = new System.Drawing.Size(75, 44);
            this.ExportBut.TabIndex = 4;
            this.ExportBut.Text = "Экспорт в Excel";
            this.ExportBut.UseVisualStyleBackColor = true;
            this.ExportBut.Click += new System.EventHandler(this.ExportBut_Click);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 326);
            this.Controls.Add(this.ExportBut);
            this.Controls.Add(this.Savebutton);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.GridUserList);
            this.Name = "UserList";
            this.Text = "Список пользователей";
            ((System.ComponentModel.ISupportInitialize)(this.GridUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridUserList;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Savebutton;
        private System.Windows.Forms.Button ExportBut;
    }
}