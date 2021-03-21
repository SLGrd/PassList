using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PassPrm
{
    public partial class FrmChild : Form
    {
        public FrmChild(string[] Cores, ref string[] CoresByRef, List<string> CoresList, ref List<string> CoresListByRef)
        {
            InitializeComponent();
            //  Display textos
            this.Text = "FORM AUXILIAR CHILD";
            lblTexto.Text = "Este formulario(child) mostra os parametros recebidos do formulario(parent)";

            //  Add 1 item to each array or list received
            Array.Resize(ref Cores, Cores.Length + 1);
            Cores[^1] = "Branco I";                      // ====== >>>>  Nova notação : ^1 = ultimo item de uma array. ^2 = penultimo
            cmbCores.DataSource = Cores;
            string w = Cores[^2];                        // Exemplo de como indexar o penultimo item de uma array

            //  Adding items to an existing array
            Array.Resize(ref CoresByRef, CoresByRef.Length + 1);
            CoresByRef[^1] = "Branco II";               // ====== >>>>  Nova notação : ^1 = ultimo item de uma array.
            cmbCoresByRef.DataSource = CoresByRef;

            //  Add 1 item to received list
            CoresList.Add("Branco III");
            cmbCoresList.DataSource = CoresList;

            //  Add 1 item to received list
            CoresListByRef.Add("Branco IV");
            cmbCoresListByRef.DataSource = CoresListByRef;
        }        
        private void BtnCallForm_Click(object sender, EventArgs e)
        {
            // Set o flag de resultado.Sera usado no form que chamou
            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //Set o flag de resultado.Sera usado no form que chamou
            this.DialogResult = DialogResult.Cancel;
        }
    }
}