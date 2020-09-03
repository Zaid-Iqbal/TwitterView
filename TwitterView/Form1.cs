using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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

namespace TwitterView
{
    public partial class Form1 : Form
    {
        IWorkbook Twb = new XSSFWorkbook(@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Twitter.xlsx");
        IWorkbook Hwb = new XSSFWorkbook(@"C:\Users\email\Desktop\Hardware Hub\HHPosts.xlsx");

        int MouseX = -1;
        int MouseY = -1;
        int MouseRow = -1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Initialize Table
            ISheet Tws = Twb.GetSheetAt(0);
            ISheet Hws = Hwb.GetSheetAt(0);

            calendar.Hide();

            recheckid:
            for (int x = 0; x <= Tws.LastRowNum; x++)
            {
                if (Tws.LastRowNum != 0)
                {
                    IRow Trow = Tws.GetRow(x);
                    bool found = false;
                    String id = Trow.Cells[1].ToString();
                    for (int y = 1; y <= Hws.LastRowNum; y++)
                    {
                        IRow Hrow = Hws.GetRow(y);
                        if (id == Hrow.Cells[5].ToString())
                        {
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        Tws.RemoveRow(Tws.GetRow(x));
                        if (x != Tws.LastRowNum)
                        {
                            Tws.ShiftRows(x + 1, Tws.LastRowNum, -1);
                        }
                        goto recheckid;
                    }
                }
                else
                {
                    break;
                }
            }

            restart:
            for (int x = 1; x <= Tws.LastRowNum; x++)
            {
                IRow Trow = Tws.GetRow(x);
                if (Trow.Cells[0].ToString() != "")
                {
                    String id = Trow.Cells[1].ToString();
                    String sent;
                    String tags;
                    String date;
                    try
                    {
                        sent = Trow.Cells[2].ToString();
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        sent = "Not Labeled (Error1: Form1.Load())";
                    }
                    if(sent == null || sent == "")
                    {
                        sent = "Not Labeled (Error2: Form1.Load())";
                    }

                    try
                    {
                        int noCount = 0;
                        if (DGV.Rows.Count > 1)
                        {
                            foreach (DataGridViewRow row in DGV.Rows)
                            {
                                try
                                {
                                    if (row.Index+1 != DGV.Rows.Count && row.Cells[4].Value.ToString() == "No")
                                    {
                                        noCount++;
                                    }
                                }
                                catch (System.NullReferenceException)
                                {
                                    
                                }
                                
                            }
                        }
                        
                        if (sent == "No")
                        {
                            if(noCount == 0)
                            {
                                DateTime editDate = Convert.ToDateTime(Formatting.FormatDate(Trow.Cells[3].ToString()));
                                if (editDate < DateTime.Now)
                                {
                                    if (DateTime.Now.Hour < 16)
                                    {
                                        editDate = DateTime.Now;
                                    }
                                    else
                                    {
                                        editDate = DateTime.Now.AddDays(1);
                                    }
                                    date = editDate.ToString("D");
                                }
                                else
                                {
                                    date = DateTime.Now.ToString("D");
                                }
                            }
                            else
                            {
                                DateTime change = Convert.ToDateTime(Formatting.FormatDate(DGV.Rows[DGV.Rows.Count - 2].Cells[5].Value.ToString()));
                                change = change.AddDays(1);
                                date = change.ToString("D");
                            }
                            
                        }
                        else if(sent == "Yes")
                        {
                            date = Trow.Cells[3].ToString();
                        }
                        else
                        {
                            date = "'Sent' cell in Twitter.xlsx is not labeled with 'Yes' Or 'No'";
                        }
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        date = "Not Labeled (Error3: Form1.Load())";
                    }
                    if (date == null || date == "")
                    {
                        sent = "Not Labeled (Error4: Form1.Load())";
                    }

                    try
                    {
                        tags = Trow.Cells[4].ToString();
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        tags = "";
                    }
                    if (tags == null || tags == "")
                    {
                        tags = "";
                    }

                    for (int y = 1; y < Hws.LastRowNum; y++)
                    {
                        IRow Prow = Hws.GetRow(y);
                        if (Prow.Cells[0].ToString() != "Stop")
                        {
                            if (id == Prow.Cells[5].ToString())
                            {
                                DataGridViewRow row = (DataGridViewRow)DGV.Rows[0].Clone();
                                row.Cells[0].Value = Trow.Cells[0].ToString();
                                row.Cells[1].Value = int.Parse(Prow.Cells[1].ToString());
                                row.Cells[2].Value = int.Parse(Prow.Cells[2].ToString());
                                row.Cells[3].Value = int.Parse(Prow.Cells[3].ToString());
                                row.Cells[4].Value = sent;
                                row.Cells[5].Value = date;
                                MemoryStream stream = new MemoryStream();
                                Image pic = Image.FromFile(@"C:\Users\email\Desktop\Hardware Hub\images\" + Prow.Cells[5] + ".png");
                                pic.Save(stream, pic.RawFormat);
                                row.Cells[6].Value = Formatting.TweetBody(Trow.Cells[0].ToString(),Prow.Cells[1].ToString(),Prow.Cells[3].ToString(),Trow.Cells[4].ToString()).Length;
                                row.Cells[7].Value = pic;
                                row.Cells[8].Value = Prow.Cells[5].ToString();
                                row.Cells[9].Value = Trow.Cells[4].ToString();
                                row.Height = 100;
                                DGV.Rows.Add(row);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }
                
            }
            #endregion
        }

        private void IDBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                String ID = IDBox.Text;
                if (ID.Substring(0, 1) == "\t")
                {
                    ID = ID.Remove(0,1);
                }
                ISheet Pws = Hwb.GetSheetAt(0);
                for (int i = 1; i < Pws.LastRowNum; i++)
                {
                    IRow Prow = Pws.GetRow(i);
                    if (Prow.Cells[0].ToString() != "Stop" && Prow.Cells[5].ToString() == ID)
                    {

                        DataGridViewRow row = (DataGridViewRow)DGV.Rows[0].Clone();
                        row.Cells[0].Value = Prow.Cells[0].ToString();
                        row.Cells[1].Value = int.Parse(Prow.Cells[1].ToString());
                        row.Cells[2].Value = int.Parse(Prow.Cells[2].ToString());
                        row.Cells[3].Value = int.Parse(Prow.Cells[3].ToString());
                        row.Cells[4].Value = "No";
                        row.Cells[5].Value = Formatting.GetNextDate(DGV);
                        MemoryStream stream = new MemoryStream();
                        Image pic = Image.FromFile(@"C:\Users\email\Desktop\Hardware Hub\images\" + Prow.Cells[5] + ".png");
                        pic.Save(stream, pic.RawFormat);
                        row.Cells[6].Value = Formatting.TweetBody(Prow.Cells[0].ToString(), Prow.Cells[1].ToString(), Prow.Cells[3].ToString(), Formatting.ListToHashTags(Formatting.HashTagsFromFile(Prow.Cells[4].ToString()))).Length;
                        row.Cells[7].Value = pic;
                        row.Cells[8].Value = Prow.Cells[5].ToString();
                        row.Cells[9].Value = Formatting.ListToHashTags(Formatting.HashTagsFromFile(Prow.Cells[4].ToString()));
                        row.Height = 100;
                        DGV.Rows.Add(row);

                        IDBox.Clear();

                        return;
                    }
                    else if (Prow.Cells[0].ToString() == "Stop")
                    {
                        MessageBox.Show("Product not found (Error in IDBOX_KeyDown() method)");
                        return;
                    }
                }
            }
        }

        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            
            IWorkbook wb = new XSSFWorkbook();
            ISheet ws = wb.CreateSheet("Tweets");

            IRow header = ws.CreateRow(0);
            header.CreateCell(0).SetCellValue("Name");
            header.CreateCell(1).SetCellValue("ID");
            header.CreateCell(2).SetCellValue("Sent");
            header.CreateCell(3).SetCellValue("Date");
            header.CreateCell(4).SetCellValue("Tags");
            header.CreateCell(5).SetCellValue("Body");

            int rowcount = 1;
            foreach (DataGridViewRow row in DGV.Rows)
            {
                if(rowcount == DGV.Rows.Count)
                {
                    break;
                }
                IRow Trow = ws.CreateRow(rowcount);

                Trow.CreateCell(0).SetCellValue(row.Cells[0].Value.ToString());
                Trow.CreateCell(1).SetCellValue(row.Cells[8].Value.ToString());
                Trow.CreateCell(2).SetCellValue(row.Cells[4].Value.ToString());
                Trow.CreateCell(3).SetCellValue(row.Cells[5].Value.ToString());
                Trow.CreateCell(4).SetCellValue(row.Cells[9].Value.ToString());
                String body = Formatting.TweetBody(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[9].Value.ToString());
                Trow.CreateCell(5).SetCellValue(body.Length + ": " + body);

                rowcount++;
            }

            Twb.Close();
            wb.Write(new FileStream(@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Twitter.xlsx",FileMode.Create,FileAccess.Write,FileShare.ReadWrite));
            wb.Close();
            Twb = new XSSFWorkbook(@"C:\Users\email\Desktop\Hardware Hub\Twitter code files\Twitter.xlsx");

        }

        private void DGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Application.OpenForms.OfType<System.Windows.Forms.Form>().Count() == 0)
            {
                return;
            }
            int row = e.RowIndex;
            // if change to title
            if (DGV.SelectedCells[0].ColumnIndex == 0 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }

            //if change to tags
            if (DGV.SelectedCells[0].ColumnIndex == 9 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }
        }

        private void DGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            // if change to title
            if (DGV.SelectedCells[0].ColumnIndex == 0 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }

            //if change to tags
            if (DGV.SelectedCells[0].ColumnIndex == 9 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }
        }

        //TODO
        private void DGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int row = e.RowIndex;
            // if change to title
            if (DGV.SelectedCells[0].ColumnIndex == 0 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }

            //if change to tags
            if (DGV.SelectedCells[0].ColumnIndex == 9 && row != DGV.Rows.Count - 1)
            {
                try
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                }
                catch (NullReferenceException)
                {
                    DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                }
            }
        }

        private void DGV_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && DGV.SelectedCells.Count == 1)
            {
                int row = DGV.CurrentCell.RowIndex;
                // if change to title
                if (DGV.SelectedCells[0].ColumnIndex == 0 && row != DGV.Rows.Count - 1)
                {
                    try
                    {
                        DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                    }
                    catch (NullReferenceException)
                    {
                        DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                    }
                }

                //if change to tags
                if (DGV.SelectedCells[0].ColumnIndex == 9 && row != DGV.Rows.Count - 1)
                {
                    try
                    {
                        DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), DGV.Rows[row].Cells[9].Value.ToString()).Length;
                    }
                    catch (NullReferenceException)
                    {
                        DGV.Rows[row].Cells[6].Value = Formatting.TweetBody(DGV.Rows[row].Cells[0].Value.ToString(), DGV.Rows[row].Cells[1].Value.ToString(), DGV.Rows[row].Cells[3].Value.ToString(), "").Length;
                    }
                }
            }

            if(e.KeyCode == Keys.Left)
            {
                if(DGV.SelectedCells.Count == 1 && DGV.CurrentCell.ColumnIndex != 0)
                {
                    DGV.CurrentCell = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.CurrentCell.ColumnIndex - 1];
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (DGV.SelectedCells.Count == 1 && DGV.CurrentCell.ColumnIndex != 9)
                {
                    DGV.CurrentCell = DGV.Rows[DGV.CurrentCell.RowIndex].Cells[DGV.CurrentCell.ColumnIndex + 1];
                }
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                moveUp();
            }
            if (e.KeyCode.Equals(Keys.Down))
            {
                moveDown();
            }
            e.Handled = true;
        }

        private void moveUp()
        {
            if (DGV.RowCount > 0)
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    int rowCount = DGV.Rows.Count;
                    int index = DGV.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                    {
                        return;
                    }
                    DataGridViewRowCollection rows = DGV.Rows;

                    // remove the previous row and add it behind the selected row.
                    DataGridViewRow row = rows[index];
                    DataGridViewRow prevRow = rows[index - 1];
                    String rowDate = row.Cells[5].Value.ToString();
                    String prevRowDate = prevRow.Cells[5].Value.ToString();
                    row.Cells[5].Value = prevRowDate;
                    prevRow.Cells[5].Value = rowDate;
                    rows.Remove(prevRow);
                    prevRow.Frozen = false;
                    rows.Insert(index, prevRow);
                    DGV.ClearSelection();
                    DGV.Rows[index - 1].Selected = true;
                }
                else if (DGV.SelectedCells.Count == 1 && DGV.CurrentCell.RowIndex != 0)
                {
                    DGV.CurrentCell = DGV.Rows[DGV.CurrentCell.RowIndex-1].Cells[DGV.CurrentCell.ColumnIndex];
                }
            }
        }

        private void moveDown()
        {
            if (DGV.RowCount > 0)
            {
                if (DGV.SelectedRows.Count > 0)
                {
                    int rowCount = DGV.Rows.Count;
                    int index = DGV.SelectedCells[0].OwningRow.Index;

                    if (index == (rowCount - 2)) // include the header row
                    {
                        return;
                    }
                    DataGridViewRowCollection rows = DGV.Rows;

                    // remove the next row and add it in front of the selected row.
                    DataGridViewRow row = rows[index];
                    DataGridViewRow prevRow = rows[index + 1];
                    String rowDate = row.Cells[5].Value.ToString();
                    String prevRowDate = prevRow.Cells[5].Value.ToString();
                    row.Cells[5].Value = prevRowDate;
                    prevRow.Cells[5].Value = rowDate;
                    DataGridViewRow nextRow = rows[index + 1];
                    rows.Remove(nextRow);
                    nextRow.Frozen = false;
                    rows.Insert(index, nextRow);
                    DGV.ClearSelection();
                    DGV.Rows[index + 1].Selected = true;
                }
                else if (DGV.SelectedCells.Count == 1 && DGV.CurrentCell.RowIndex != DGV.Rows.Count-2)
                {
                    DGV.CurrentCell = DGV.Rows[DGV.CurrentCell.RowIndex+1].Cells[DGV.CurrentCell.ColumnIndex];
                }
            }
        }

        private void DGV_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                int mousCol = DGV.HitTest(e.X, e.Y).ColumnIndex;
                int mousRow = DGV.HitTest(e.X, e.Y).RowIndex;

                if (mousCol == 5 && DGV.SelectedCells.Count == 1 && DGV.SelectedCells[0].ColumnIndex == 5 && DGV.SelectedCells[0].RowIndex == mousRow)
                {
                    DateMenu.Show(Cursor.Position);
                    MouseX = e.X;
                    MouseY = e.Y;
                    MouseRow = DGV.HitTest(e.X, e.Y).RowIndex;
                }

                if(mousCol == -1 && DGV.SelectedRows.Count == 1 && DGV.SelectedRows[0].Index == mousRow)
                {
                    menu.Show(Cursor.Position);
                    MouseX = e.X;
                    MouseY = e.Y;
                    MouseRow = DGV.HitTest(e.X, e.Y).RowIndex;
                    DGV.Rows[MouseRow].Selected = true;
                }

                if (mousCol == 0 && DGV.SelectedCells.Count == 1 && DGV.SelectedCells[0].ColumnIndex == 0 && DGV.SelectedCells[0].RowIndex == mousRow)
                {
                    NameMenu.Show(Cursor.Position);
                    MouseX = e.X;
                    MouseY = e.Y;
                    MouseRow = DGV.HitTest(e.X, e.Y).RowIndex;
                }
            }
        }

        private void revertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String ID = DGV.Rows[MouseRow].Cells[8].Value.ToString();
            try
            {
                ISheet ws = Hwb.GetSheetAt(0);
                for (int x = 0; x < ws.LastRowNum; x++)
                {
                    IRow row = ws.GetRow(x);
                    if(row.Cells[0].ToString() != "Stop")
                    {
                        if(ID == row.Cells[5].ToString())
                        {
                            DGV.SelectedCells[0].Value = row.Cells[0].ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: Post not found");
                        break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            NameMenu.Hide();
        }

        private void changeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calendar.Location = new Point(MouseX,MouseY);
            calendar.Show();
            DateMenu.Hide();
        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DGV.Rows.Remove(DGV.Rows[MouseRow]);
            menu.Hide();
        }

        private void calendar_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DGV.Rows[MouseRow].Cells[5].Value = calendar.Value.ToString("D");
                calendar.Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        #region accidents
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void menu_MouseClick(object sender, MouseEventArgs e)
        {

        }






        #endregion

        
    }
}
