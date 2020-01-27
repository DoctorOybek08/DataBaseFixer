using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlDifference
{
    public partial class Form1 : Form
    {
        private Connect sql = new Connect();
        private Connect sql_select = new Connect();
        public Form1()
        {
            InitializeComponent();
            sql.Connection();
            sql_select.Connection();
        }

        private void difference_Click(object sender, EventArgs e)
        {  
            if (database1.Text != "" && database2.Text != "")
            {
                label5.Text =  database2.Text + " - " + database1.Text;
                var select3 = "";
                if (sql1.Text == "")
                {
                    select3 = "SELECT t.COLUMN_NAME as Field, COLUMN_TYPE as type, IS_NULLABLE as Null_Value, COLUMN_KEY as Key_Value, COLUMN_DEFAULT as Def_Value, EXTRA as extra, table_name FROM information_schema.COLUMNS as t where table_schema='" + database2.Text + "' and COLUMN_NAME " +
    "not in " +
        "(SELECT COLUMN_NAME as Field FROM information_schema.COLUMNS as t2 where table_schema='" + database1.Text + "'  and t.TABLE_NAME = t2.TABLE_NAME)";
                }
                else
                {
                    select3 = "SELECT t.COLUMN_NAME as Field, COLUMN_TYPE as type, IS_NULLABLE as Null_Value, COLUMN_KEY as Key_Value, COLUMN_DEFAULT as Def_Value, EXTRA as extra, table_name FROM information_schema.COLUMNS as t where table_schema='" + database2.Text + "' and table_name = '" + sql1.Text + "' and COLUMN_NAME " +
                      "not in " +
                          "(SELECT COLUMN_NAME as Field FROM information_schema.COLUMNS as t2 where table_schema='" + database1.Text + "'  and t.TABLE_NAME = t2.TABLE_NAME)";
                }
                sql.myReader = sql.return_MySqlCommand(select3).ExecuteReader();
                int index = 0;
                dataGridView1.Rows.Clear();
                while (sql.myReader.Read())
                {
                    index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = (sql.myReader["Field"] != DBNull.Value ? sql.myReader.GetString("Field") : "");
                    dataGridView1.Rows[index].Cells[1].Value = (sql.myReader["type"] != DBNull.Value ? sql.myReader.GetString("type") : "");
                    dataGridView1.Rows[index].Cells[2].Value = (sql.myReader["Null_Value"] != DBNull.Value ? sql.myReader.GetString("Null_Value") : "");
                    dataGridView1.Rows[index].Cells[3].Value = (sql.myReader["Key_Value"] != DBNull.Value ? sql.myReader.GetString("Key_Value") : "");
                    dataGridView1.Rows[index].Cells[4].Value = (sql.myReader["Def_Value"] != DBNull.Value ? sql.myReader.GetString("Def_Value") : "");
                    dataGridView1.Rows[index].Cells[5].Value = (sql.myReader["extra"] != DBNull.Value ? sql.myReader.GetString("extra") : "");
                    dataGridView1.Rows[index].Cells[6].Value = (sql.myReader["table_name"] != DBNull.Value ? sql.myReader.GetString("table_name") : "");
                }
                sql.myReader.Close();

//                 select3 = "SELECT t.COLUMN_NAME as Field, COLUMN_TYPE as type, IS_NULLABLE as Null_Value, COLUMN_KEY as Key_Value, COLUMN_DEFAULT as Def_Value, EXTRA as extra, table_name FROM information_schema.COLUMNS as t where table_schema='" + database1.Text + "' and COLUMN_NAME " +
//"not in " +
//"(SELECT COLUMN_NAME as Field FROM information_schema.COLUMNS as t2 where table_schema='" + database2.Text + "'  and t.TABLE_NAME = t2.TABLE_NAME)";
//                sql.myReader = sql.return_MySqlCommand(select3).ExecuteReader();
//                 index = 0;
                
//                while (sql.myReader.Read())
//                {
//                    index = dataGridView3.Rows.Add();
//                    dataGridView3.Rows[index].Cells[0].Value = (sql.myReader["Field"] != DBNull.Value ? sql.myReader.GetString("Field") : "");
//                    dataGridView3.Rows[index].Cells[1].Value = (sql.myReader["type"] != DBNull.Value ? sql.myReader.GetString("type") : "");
//                    dataGridView3.Rows[index].Cells[2].Value = (sql.myReader["Null_Value"] != DBNull.Value ? sql.myReader.GetString("Null_Value") : "");
//                    dataGridView3.Rows[index].Cells[3].Value = (sql.myReader["Key_Value"] != DBNull.Value ? sql.myReader.GetString("Key_Value") : "");
//                    dataGridView3.Rows[index].Cells[4].Value = (sql.myReader["Def_Value"] != DBNull.Value ? sql.myReader.GetString("Def_Value") : "");
//                    dataGridView3.Rows[index].Cells[5].Value = (sql.myReader["extra"] != DBNull.Value ? sql.myReader.GetString("extra") : "");
//                    dataGridView3.Rows[index].Cells[6].Value = (sql.myReader["table_name"] != DBNull.Value ? sql.myReader.GetString("table_name") : "");
//                }
//                sql.myReader.Close();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string null_val = "";
                string default_val = "";
                if (dataGridView1.Rows.Count > 1)
                {
                    button3.BackColor = Color.Red;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[2].Value.ToString() == "YES")
                            {
                                null_val = "NULL";
                            }
                            else
                            {
                                null_val = "NOT NULL";
                            }

                            if (row.Cells[4].Value.ToString() != null || row.Cells[4].Value.ToString() != "")
                            {
                                default_val = row.Cells[4].Value.ToString();
                            }
                            if (row.Cells[3].Value.ToString() == "PRI")
                            {
                                var query = "CREATE TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` (`" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + " " + row.Cells[5].Value + ", PRIMARY KEY (`" + row.Cells[0].Value + "`));";
                                sql.return_MySqlCommand(query).ExecuteNonQuery();
                            }
                            else
                            {
                                var query = "SHOW COLUMNS FROM `" + database1.Text + "`.`" + row.Cells[6].Value + "` LIKE '" + row.Cells[0].Value + "'";
                                sql.myReader = sql.return_MySqlCommand(query).ExecuteReader();
                                DataTable table = new DataTable();
                                table.Load(sql.myReader);
                                int count = table.Rows.Count;
                                if (count == 0)
                                {
                                    if (default_val != "")
                                    {
                                        if (default_val == "CURRENT_TIMESTAMP")
                                        {
                                            var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + " DEFAULT " + default_val + ";";
                                            sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + " DEFAULT '" + default_val + "';";
                                            sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + ";";
                                        sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    if (default_val != "")
                                    {
                                        if (default_val == "CURRENT_TIMESTAMP")
                                        {
                                            var delete = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` DROP COLUMN `" + row.Cells[0].Value + "` ";
                                            sql.return_MySqlCommand(delete).ExecuteNonQuery();
                                            var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + " DEFAULT " + default_val + ";";
                                            sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            var delete = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` DROP COLUMN `" + row.Cells[0].Value + "` ";
                                            sql.return_MySqlCommand(delete).ExecuteNonQuery();
                                            var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + " DEFAULT '" + default_val + "';";
                                            sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        var delete = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` DROP COLUMN `" + row.Cells[0].Value + "` ";
                                        sql.return_MySqlCommand(delete).ExecuteNonQuery();
                                        var insert = "ALTER TABLE `" + database1.Text + "`.`" + row.Cells[6].Value + "` ADD COLUMN `" + row.Cells[0].Value + "` " + row.Cells[1].Value + " " + null_val + ";";
                                        sql.return_MySqlCommand(insert).ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("DONE");
                    button3.BackColor = Color.FromKnownColor(KnownColor.Control);
                    dataGridView1.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXUCUTE ERROR: ", ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = System.IO.File.ReadAllText("docs\\ip.txt");
                string db = database1.Text;
                string username = "root";
                string password = "1101jamshid";
                string constring = "server=" + ip + ";user=" + username + ";pwd=" + password + ";database=" + db + ";";

                string mytime = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
                string file = Environment.CurrentDirectory +  "\\back_ups\\" + mytime + ".sql";
                string file1 = " ";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            file1 = file;
                            if (!File.Exists(Environment.CurrentDirectory + "\\back_ups\\" + mytime + ".sql"))
                            {
                                int fCount = Directory.GetFiles(Environment.CurrentDirectory + "\\back_ups\\", "*", SearchOption.TopDirectoryOnly).Length;
                                if (fCount < 30)
                                {
                                    mb.ExportToFile(file1);
                                }
                                else
                                {
                                    DateTime dateForButton = DateTime.Now.AddDays(-30);
                                    MessageBox.Show("Date for delete " + dateForButton.ToString());
                                    MessageBox.Show(Environment.CurrentDirectory);
                                    File.Delete(Environment.CurrentDirectory + "\\back_ups\\" + dateForButton.Day.ToString() + "-" + dateForButton.Month.ToString() + "-" + dateForButton.Year.ToString() + ".sql");
                                    mb.ExportToFile(file1);
                                }
                            }

                            conn.Close();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception Occured " + ex);
            }
        }
    }
}
