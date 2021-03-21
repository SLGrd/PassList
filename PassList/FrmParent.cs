using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PassPrm
{
    public partial class FrmParent : Form
    {
        //  Variaveis para teste     
        private string[] Colors              = { "Amarelo", "Azul", "Verde", "Vermelho", "Preto" };
        private string[] ColorsByRef         = { "Amarelo", "Azul", "Verde", "Vermelho", "Preto" };
        private List<string> ColorsList      = new() { "Amarelo", "Azul", "Verde", "Vermelho", "Preto" };
        private List<string> ColorsListByRef = new() { "Amarelo", "Azul", "Verde", "Vermelho", "Preto" };

        public FrmParent()
        {
            InitializeComponent();
            //  Inicializando controles que receberão os parametros a enviar e receber
            this.Text = "PASSING PARAMETERS";
            lblTexto.Text = "Este formulario(parent) chama e passa parametros para o form CHILD";

            cmbColors.DataSource          = Colors;
            cmbColorsByRef.DataSource     = ColorsByRef;
            cmbColorsList.DataSource      = ColorsList;
            cmbColorsListByRef.DataSource = ColorsListByRef;
        }
        private void BtnCallForm_Click(object sender, EventArgs e)
        {
            //  Criando instancia do form child
            using FrmChild frmChild = new FrmChild( Colors, ref ColorsByRef, ColorsList, ref ColorsListByRef);

            //  Localizacao do from child para facilidade e visualizacao
            frmChild.StartPosition = FormStartPosition.Manual;
            frmChild.Location = new Point(Location.X + Size.Width / 2,
                                          Location.Y + Size.Height / 2); ;
            //  Show chilf form em modal
            frmChild.ShowDialog();
            if (frmChild.DialogResult == DialogResult.OK)
            {
                //  O usuario clicou OK no form CHILD
                cmbColors.DataSource          = Colors;
                cmbColorsByRef.DataSource     = ColorsByRef;
                cmbColorsList.DataSource      = ColorsList;

                cmbColorsListByRef.DataSource = null;  // ==========>>>  To force refresh veja
                                                       // https://stackoverflow.com/questions/49681468/modifying-original-datasource-doesnt-update-combobox
                cmbColorsListByRef.DataSource = ColorsListByRef;                
            };
            if (frmChild.DialogResult == DialogResult.Cancel)
            {
                //  O usuario clicou o botao de CANCEL no form CHILD;
            };
        }
    }
}