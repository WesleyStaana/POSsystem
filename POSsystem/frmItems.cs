﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace POSsystem
{
    public partial class frmItems : Form
    {
        private frmTransactionAddItem transaction = null;
        public void setItem(frmTransactionAddItem test)
        {
            transaction = test;
        }

        private String connectionString = "SERVER=localhost;DATABASE=possystem_db;UID=root;PASSWORD=staana0522;charset=utf8;";
        public frmItems()
        {
            InitializeComponent();
            lvItems.Click += new System.EventHandler(lvItems_Click);
        }

        private void frmItems_Load(object sender, EventArgs e)
        {
            this.loadItemList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmItemAddItem addItem = new frmItemAddItem();
            addItem.ShowDialog();
            this.loadItemList();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            frmStockIn stockIn = new frmStockIn();
            stockIn.ShowDialog();
            this.loadItemList();
        }

        public void loadItemList()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT * FROM items_tbl";

            adapter.SelectCommand = command;

            MySqlCommandBuilder commandBuilder = new MySqlCommandBuilder(adapter);

            conn.Open();

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "items_tbl");
            lvItems.Items.Clear();
            for (int index = 0; index < dataSet.Tables[0].Rows.Count; index++)
            {
                lvItems.Items.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(0).ToString());
                lvItems.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(1).ToString());
                lvItems.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(2).ToString());
                lvItems.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(3).ToString());
                lvItems.Items[index].SubItems.Add(dataSet.Tables[0].Rows[index].ItemArray.GetValue(4).ToString());
                

            }

            conn.Close();
        }
        private void lvItems_Click(Object sender, EventArgs e)
        {
            
            
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvItems_ItemActivate(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

           
            frmUpdateItem frm = new frmUpdateItem(lvItems.SelectedItems);
            frm.ShowDialog();
            this.loadItemList();

        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem item = lvItems.SelectedItems[0];
            transaction.setTxtItemCode(item.Text);
            transaction.setTxtItemName(item.SubItems[1].Text);
            transaction.setTxtUnitPrice(item.SubItems[3].Text);
            this.Hide();
        }

        private void frmItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}

