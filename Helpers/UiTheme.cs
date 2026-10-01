using System; using System.Drawing; using System.Windows.Forms;
namespace UCSPyayStudentRegistration.Helpers {
 public class StyledForm:Form {
  protected override void OnLoad(EventArgs e){base.OnLoad(e);UiTheme.Apply(this);}
 }
 public static class UiTheme {
  public static readonly Color Navy=Color.FromArgb(18,73,120), Blue=Color.FromArgb(31,111,180), Pale=Color.FromArgb(242,247,251), Border=Color.FromArgb(210,222,232), Text=Color.FromArgb(38,50,60);
  public static void Apply(Form f){f.Font=new Font("Segoe UI",9F);f.BackColor=Pale;f.ForeColor=Text;if(f.StartPosition==FormStartPosition.WindowsDefaultLocation)f.StartPosition=FormStartPosition.CenterParent;StyleChildren(f.Controls);}
  static void StyleChildren(Control.ControlCollection controls){foreach(Control c in controls){var b=c as Button;if(b!=null){b.FlatStyle=FlatStyle.Flat;b.FlatAppearance.BorderSize=0;b.BackColor=Blue;b.ForeColor=Color.White;b.Cursor=Cursors.Hand;b.Padding=new Padding(5,0,5,0);if(b.Height<34)b.Height=34;b.TextAlign=ContentAlignment.MiddleCenter;}var g=c as DataGridView;if(g!=null){if(g.ReadOnly){g.AllowUserToAddRows=false;g.AllowUserToDeleteRows=false;}g.BackgroundColor=Color.White;g.BorderStyle=BorderStyle.None;g.RowHeadersVisible=false;g.EnableHeadersVisualStyles=false;g.ColumnHeadersDefaultCellStyle.BackColor=Navy;g.ColumnHeadersDefaultCellStyle.ForeColor=Color.White;g.ColumnHeadersDefaultCellStyle.Font=new Font("Segoe UI",9F,FontStyle.Bold);g.ColumnHeadersHeight=36;g.DefaultCellStyle.SelectionBackColor=Color.FromArgb(210,231,247);g.DefaultCellStyle.SelectionForeColor=Text;g.AlternatingRowsDefaultCellStyle.BackColor=Color.FromArgb(247,250,252);g.RowTemplate.Height=30;}var t=c as TextBox;if(t!=null)t.BorderStyle=BorderStyle.FixedSingle;var p=c as Panel;if(p!=null&&p.BackColor==SystemColors.Control)p.BackColor=Pale;var fp=c as FlowLayoutPanel;if(fp!=null&&fp.BackColor==SystemColors.Control)fp.BackColor=Pale;if(c.HasChildren)StyleChildren(c.Controls);}}
  public static Label Heading(string title,string subtitle){return new Label{Text=title+"\r\n"+subtitle,Dock=DockStyle.Top,Height=72,Padding=new Padding(18,10,0,0),BackColor=Navy,ForeColor=Color.White,Font=new Font("Segoe UI",15F,FontStyle.Bold)};}
  public static Button Secondary(string text){var b=new Button{Text=text,Width=120,Height=36,BackColor=Color.FromArgb(91,106,117),ForeColor=Color.White,FlatStyle=FlatStyle.Flat};b.FlatAppearance.BorderSize=0;return b;}
 }
}
