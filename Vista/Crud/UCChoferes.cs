﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Componerntes;

namespace Vista.Crud
{
    public partial class UCChoferes : UserControl
    {
        public UCChoferes()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            choferesBindingSource.AddNew();
            estado(true);
        }

        private void estado(bool state)
        {
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;

            btnModificar.Enabled = !state;
            btnNuevo.Enabled = !state;
            btnEliminar.Enabled = !state;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estado(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("¿Está seguro de eliminar este registro?", "Eliminar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dialog == DialogResult.No) return;

            choferesBindingSource.RemoveAt(choferesBindingSource.Position);
            this.tableAdapterManager.UpdateAll(this.dBTransporte);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.choferesBindingSource.CancelEdit();
            estado(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // validaciones
            if(dniTextBox.Text == "")
            {
                errorProvider1.SetError(dniTextBox, "El campo dni esta vacía");
                dniTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (nombresTextBox.Text == "")
            {
                errorProvider1.SetError(nombresTextBox, "El campo nombre esta vacía");
                nombresTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (apellidosTextBox.Text == "")
            {
                errorProvider1.SetError(apellidosTextBox, "El campo apellidos esta vacía");
                apellidosTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (telefonoTextBox.Text == "")
            {
                errorProvider1.SetError(telefonoTextBox, "El campo telefono esta vacía");
                telefonoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (emailTextBox.Text == "")
            {
                errorProvider1.SetError(emailTextBox, "El campo email esta vacía");
                emailTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (direccionTextBox.Text == "")
            {
                errorProvider1.SetError(direccionTextBox, "El campo dirrecion esta vacía");
                direccionTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (id_licenciaComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(id_licenciaComboBox, "El campo licencia esta vacía");
                id_licenciaComboBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (id_empresaComboBox.SelectedIndex == -1)
            {
                errorProvider1.SetError(id_empresaComboBox, "El campo empresa esta vacía");
                id_empresaComboBox.Focus();
                return;
            }
            errorProvider1.Clear();
            this.Validate();
            this.choferesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dBTransporte);
            estado(false);
        }

        private void UCChoferes_Load(object sender, EventArgs e)
        {
            choferesTableAdapter.Fill(dBTransporte.choferes);
            licenciasTableAdapter.Fill(dBTransporte.licencias);
            empresasTableAdapter.Fill(dBTransporte.empresas);
            estado(false);
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.isNumber(e);
        }
    }
}
