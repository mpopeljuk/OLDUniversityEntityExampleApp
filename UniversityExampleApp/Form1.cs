using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityExampleApp.Models;
using UniversityExampleApp.Projects;

namespace UniversityExampleApp
{
    public partial class Form1 : Form
    {
        UniversityEntities db;

        enum Tables
        {
            Groups,
            Students,
            Subjects,
            GroupToSubjects
        }

        public Form1()
        {
            InitializeComponent();
            db = new UniversityEntities();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by a member of Ch-028.NET group \nof SoftServe IT Academy\n\nMikePopeluk");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (tablesComboBox.Text)
            {
                case "Groups":
                    addRows(Tables.Groups);
                    break;
                case "Students":
                    addRows(Tables.Students);
                    break;
                case "Subjects":
                    addRows(Tables.Subjects);
                    break;
                case "GroupToSubject":
                    addRows(Tables.GroupToSubjects);
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tablesComboBox.DataSource = getAllTableNames();

            loadTable(Tables.Groups);

            rowAddDataGridView.RowCount = 1;

            idColumnVisible(false);
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rowAddDataGridView.Columns.Clear();
            switch (tablesComboBox.Text)
            {
                case "Groups":
                    loadTable(Tables.Groups);
                    break;
                case "Students":
                    loadTable(Tables.Students);
                    break;
                case "Subjects":
                    loadTable(Tables.Subjects);
                    break;
                case "GroupToSubject":
                    loadTable(Tables.GroupToSubjects);
                    break;
                default:
                    break;
            }
            idColumnVisible(mainDataGridView.Columns[0].Visible);
        }

        private void changeIdColumnVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idColumnVisible(!mainDataGridView.Columns[0].Visible);
        }

        private void deleteSelButton_Click(object sender, EventArgs e)
        {
            switch (tablesComboBox.Text)
            {
                case "Groups":
                    deleteRow(Tables.Groups);
                    break;
                case "Students":
                    deleteRow(Tables.Students);
                    break;
                case "Subjects":
                    deleteRow(Tables.Subjects);
                    break;
                case "GroupToSubject":
                    deleteRow(Tables.GroupToSubjects);
                    break;
                default:
                    break;
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            rowAddDataGridView.Rows.Add(CloneWithValues(mainDataGridView.CurrentRow));
        }

        /// <summary>
        /// Clone row from dataGrid with all values.
        /// </summary>
        /// <param name="row">Row that need to be cloned.</param>
        /// <returns>Cloned row with all values.</returns>
        public DataGridViewRow CloneWithValues(DataGridViewRow row)
        {
            DataGridViewRow clonedRow = (DataGridViewRow)row.Clone();
            for (Int32 index = 0; index < row.Cells.Count; index++)
            {
                clonedRow.Cells[index].Value = row.Cells[index].Value;
            }
            return clonedRow;
        }

        /// <summary>
        /// Delete row from database.
        /// </summary>
        /// <param name="table">Table name.</param>
        private void deleteRow(Tables table)
        {
            string rowId = mainDataGridView.CurrentRow.Cells[0].Value.ToString();

            switch (table)
            {
                case Tables.Groups:
                    var group = new Group { Id = int.Parse(rowId) };
                    db.Groups.Attach(group);
                    db.Groups.Remove(group);
                    db.SaveChanges();
                    loadTable(Tables.Groups);
                    break;

                case Tables.Students:
                    var student = new Student { Id = int.Parse(rowId) };
                    db.Students.Attach(student);
                    db.Students.Remove(student);
                    db.SaveChanges();
                    loadTable(Tables.Students);
                    break;

                case Tables.Subjects:
                    var subject = new Subject { Id = int.Parse(rowId) };
                    db.Subjects.Attach(subject);
                    db.Subjects.Remove(subject);
                    db.SaveChanges();
                    loadTable(Tables.Subjects);
                    break;

                case Tables.GroupToSubjects:
                    var gts = new GroupToSubject { Id = int.Parse(rowId) };
                    db.GroupToSubjects.Attach(gts);
                    db.GroupToSubjects.Remove(gts);
                    db.SaveChanges();
                    loadTable(Tables.GroupToSubjects);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Add rows from database.
        /// </summary>
        /// <param name="table">Table name.</param>
        private void addRows(Tables table)
        {
            UniversityEntities tempEntity = new UniversityEntities();

            try
            {
                switch (table)
                {
                    case Tables.Groups:
                        for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                        {
                            db.Groups.Add(new Group { Name = rowAddDataGridView.Rows[i].Cells[1].Value.ToString() });
                        }
                        db.SaveChanges();
                        loadTable(Tables.Groups);
                        rowAddDataGridView.Rows.Clear();
                        break;

                    case Tables.Students:
                        for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                        {
                            db.Students.Add(new Student
                            {
                                FirstName = rowAddDataGridView.Rows[i].Cells[1].Value.ToString(),
                                LastName = rowAddDataGridView.Rows[i].Cells[2].Value.ToString(),
                                Age = int.Parse(rowAddDataGridView.Rows[i].Cells[3].Value.ToString()),
                                GroupId = getIdFromString(rowAddDataGridView.Rows[i].Cells[4].Value.ToString())
                            });
                        }
                        db.SaveChanges();
                        loadTable(Tables.Students);
                        rowAddDataGridView.Rows.Clear();
                        break;

                    case Tables.Subjects:
                        for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                        {
                            db.Subjects.Add(new Subject { Name = rowAddDataGridView.Rows[i].Cells[1].Value.ToString() });
                        }
                        db.SaveChanges();
                        loadTable(Tables.Subjects);
                        rowAddDataGridView.Rows.Clear();
                        break;

                    case Tables.GroupToSubjects:
                        for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                        {
                            db.GroupToSubjects.Add(new GroupToSubject
                            {
                                GroupId = getIdFromString(rowAddDataGridView.Rows[i].Cells[1].Value.ToString()),
                                SubjectId = getIdFromString(rowAddDataGridView.Rows[i].Cells[2].Value.ToString()),
                            });
                        }
                        db.SaveChanges();
                        loadTable(Tables.GroupToSubjects);
                        rowAddDataGridView.Rows.Clear();
                        break;

                    default:
                        break;
                }
            }
            catch (DbUpdateException)
            {
                db = tempEntity;
                MessageBox.Show("This group allready have this subject");
            }

        }

        /// <summary>
        /// Get all table names from DBase
        /// </summary>
        /// <returns>All table names.</returns>
        private List<String> getAllTableNames()
        {
            List<String> result = new List<string>();

            var metadata = ((IObjectContextAdapter)db).ObjectContext.MetadataWorkspace;

            var tables = metadata.GetItemCollection(DataSpace.SSpace)
              .GetItems<EntityContainer>()
              .Single()
              .BaseEntitySets
              .OfType<EntitySet>()
              .Where(s => !s.MetadataProperties.Contains("Type")
                || s.MetadataProperties["Type"].ToString() == "Tables");

            foreach (var table in tables)
            {
                var tableName = table.MetadataProperties.Contains("Table")
                    && table.MetadataProperties["Table"].Value != null
                  ? table.MetadataProperties["Table"].Value.ToString()
                  : table.Name;

                //var tableSchema = table.MetadataProperties["Schema"].Value.ToString();

                result.Add(tableName);//tableSchema + "." + tableName);
            }
            return result;
        }

        /// <summary>
        /// Changes visible of first columns in both grids.
        /// </summary>
        /// <param name="f">Value of column visibility.</param>
        private void idColumnVisible(bool f)
        {
            mainDataGridView.Columns[0].Visible = f;
            rowAddDataGridView.Columns[0].Visible = f;
        }

        /// <summary>
        /// Create a DataGridViewComboBoxColumn with items of table.
        /// </summary>
        /// <param name="table">Table name you want to get values. Can be only Subject or Student table. </param>
        /// <returns>DataGridViewComboBoxColumn with items formatted (<id>,<name>).</returns>
        private DataGridViewComboBoxColumn getRelation(Tables table)
        {
            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            if (table == Tables.Groups)
            {
                cmb.HeaderText = "Select Group";
                var query = from g in db.Groups
                            select new IdNameProject { Id = g.Id, Name = g.Name };

                foreach (var item in query)
                {
                    cmb.Items.Add(item.Name + "," + item.Id);
                }
            }
            else if (table == Tables.Subjects)
            {
                cmb.HeaderText = "Select Subject";
                var query = from g in db.Subjects
                            select new IdNameProject { Id = g.Id, Name = g.Name };

                foreach (var item in query)
                {
                    cmb.Items.Add(item.Name + "," + item.Id);
                }
            }
            else
            {
                cmb.HeaderText = "Empty";
            }
            return cmb;
        }

        /// <summary>
        /// Loads table from entity to DataGridView.
        /// </summary>
        /// <param name="table">Enum table name</param>
        private void loadTable(Tables table)
        {

            switch (table)
            {
                case Tables.Groups:
                    var gQuery = from g in db.Groups
                                 select new GroupsTableProject { Id = g.Id, Name = g.Name };
                    mainDataGridView.DataSource = gQuery.ToList();
                    rowAddDataGridView.ColumnCount = mainDataGridView.ColumnCount;
                    break;

                case Tables.Students:
                    var stQuery = from g in db.Students
                                  select new StudentsTableProject { Id = g.Id, FirstName = g.FirstName, LastName = g.LastName, Age = g.Age };
                    mainDataGridView.DataSource = stQuery.ToList();
                    rowAddDataGridView.ColumnCount = mainDataGridView.ColumnCount;
                    rowAddDataGridView.Columns.Add(getRelation(Tables.Groups));
                    break;

                case Tables.Subjects:
                    var subQuery = from g in db.Subjects
                                   select new SubjectsTableProject { Id = g.Id, Name = g.Name };
                    mainDataGridView.DataSource = subQuery.ToList();
                    rowAddDataGridView.ColumnCount = mainDataGridView.ColumnCount;

                    break;

                case Tables.GroupToSubjects:
                    var gtsQuery = from g in db.GroupToSubjects
                                   select new GroupToSubjectTableProject { Id = g.Id, GroupId = g.GroupId, SubjectId = g.SubjectId };
                    mainDataGridView.DataSource = gtsQuery.ToList();
                    rowAddDataGridView.ColumnCount = 1;
                    rowAddDataGridView.Columns.Add(getRelation(Tables.Groups));
                    rowAddDataGridView.Columns.Add(getRelation(Tables.Subjects));
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Split with comma and returns last value as int. If failed - return 0.
        /// </summary>
        /// <param name="s">String you need to split.</param>
        /// <returns>Integer value. If failed - return 0.</returns>
        private int getIdFromString(string s)
        {
            int result;

            string[] splitted = s.Split(',');

            if (!int.TryParse(splitted[splitted.Length - 1], out result))
            {
                result = 0;
            }

            return result;
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            switch (tablesComboBox.Text)
            {
                case "Groups":
                    updateRows(Tables.Groups);
                    break;
                case "Students":
                    updateRows(Tables.Students);
                    break;
                case "Subjects":
                    updateRows(Tables.Subjects);
                    break;
                case "GroupToSubject":
                    updateRows(Tables.GroupToSubjects);
                    break;
                default:
                    break;
            }
        }

        private void updateRows(Tables table)
        {
            switch (table)
            {
                case Tables.Groups:
                    for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                    {
                        int rowId = int.Parse(rowAddDataGridView.Rows[i].Cells[0].Value.ToString());
                        var result = db.Groups.SingleOrDefault(b => b.Id == rowId);
                        if (result != null)
                        {
                            result.Name = rowAddDataGridView.Rows[i].Cells[1].Value.ToString();

                        }
                    }

                    db.SaveChanges();
                    loadTable(Tables.Groups);
                    rowAddDataGridView.Rows.Clear();
                    break;

                case Tables.Students:
                    for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                    {
                        int rowId = int.Parse(rowAddDataGridView.Rows[i].Cells[0].Value.ToString());
                        var result = db.Students.SingleOrDefault(b => b.Id == rowId);
                        if (result != null)
                        {
                            result.FirstName = rowAddDataGridView.Rows[i].Cells[1].Value.ToString();
                            result.LastName = rowAddDataGridView.Rows[i].Cells[2].Value.ToString();
                            result.Age = int.Parse(rowAddDataGridView.Rows[i].Cells[3].Value.ToString());
                            result.GroupId = getIdFromString(rowAddDataGridView.Rows[i].Cells[4].Value.ToString());

                        }
                    }
                    db.SaveChanges();
                    loadTable(Tables.Students);
                    rowAddDataGridView.Rows.Clear();
                    break;

                case Tables.Subjects:
                    for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                    {
                        int rowId = int.Parse(rowAddDataGridView.Rows[i].Cells[0].Value.ToString());
                        var result = db.Subjects.SingleOrDefault(b => b.Id == rowId);
                        if (result != null)
                        {
                            result.Name = rowAddDataGridView.Rows[i].Cells[1].Value.ToString();

                        }
                    }
                    db.SaveChanges();
                    loadTable(Tables.Subjects);
                    rowAddDataGridView.Rows.Clear();
                    break;

                /*case Tables.GroupToSubjects:
                    for (int i = 0; i < rowAddDataGridView.RowCount - 1; i++)
                    {
                        int rowId = int.Parse(rowAddDataGridView.Rows[i].Cells[0].Value.ToString());
                        var result = db.GroupToSubjects.SingleOrDefault(b => b.Id == rowId);
                        if (result != null)
                        {
                            result.GroupId = int.Parse(rowAddDataGridView.Rows[i].Cells[1].Value.ToString());
                            result.SubjectId = int.Parse(rowAddDataGridView.Rows[i].Cells[2].Value.ToString());
                        }
                    }
                    db.SaveChanges();
                    loadTable(Tables.GroupToSubjects);
                    rowAddDataGridView.Rows.Clear();
                    break;*/

                default:
                    break;
            }
        }


    }
}
