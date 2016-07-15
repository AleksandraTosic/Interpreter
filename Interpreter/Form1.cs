using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ScintillaNET;

namespace Interpreter
{
    public partial class Form1 : Form
    {
        private MacroLexer MacroLexer = new MacroLexer("BEGIN_PROG_ON_START DO_CLAMPS DO_PRESS_A DO_PRESS_B END_PROG_ON_START BEGIN_PROG_ON_FINISH DO_SEAL END_PROG_ON_FINISH PROGRAM_STEP BEGIN SOURCE_PLACE DEST_PLACE ACTIVE_CLAMPS SOURCE_LIQ DEST_LIQ FLOW_CONTROL REF_FLOW TIMEOUT TIME_TO_STABLE WAIT_TO_CHECKS_CONDS BEGIN_ON_START END_ON_START BEGIN_ON_FINISH LEARNING_SENSOR END_ON_FINISH BEGIN_FAIL_COND TYPE NAME VALUE EVA_A EVA_B END_FAIL_COND BEGIN_REG_COND TYPE NAME VALUE END_REG_COND END_STEP END_PROGRAM PROGRAM BAG_TYPE ALL_CLAMPS MCONTROL SLIMITA SLIMITB EDST ESPD RELAXIT DELTA POINT_L DST SPEED POINT_R PLACE LIQ CLAMP LIQPIC NET");

        public Form1()
        {
            InitializeComponent();

            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            scintilla.Lexer = Lexer.Container;

            scintilla.Styles[MacroLexer.DefaultS].ForeColor = Color.HotPink;
            scintilla.Styles[MacroLexer.KeywordS].ForeColor = Color.Blue;
            scintilla.Styles[MacroLexer.CommentS].ForeColor = Color.Green;
            scintilla.Styles[MacroLexer.NumberS].ForeColor = Color.Plum;
            scintilla.Styles[MacroLexer.CharS].ForeColor = Color.GreenYellow;
            scintilla.Styles[MacroLexer.OperatorS].ForeColor = Color.Red;
            scintilla.Styles[MacroLexer.StringS].ForeColor = Color.Honeydew;
        }

        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            var startPos = scintilla.GetEndStyled();
            var endPos = e.Position;

            MacroLexer.Style(scintilla, endPos, startPos);
        }

        private void upBut_Click(object sender, EventArgs e)
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "PRG (.prg)| *.prg";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = openFileDialog.OpenFile();
                StreamReader reader = new StreamReader(fileStream);

                scintilla.Text = reader.ReadToEnd();
           
                fileStream.Close();
            }
        }
    }
}
