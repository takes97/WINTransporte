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
    public partial class UCEmpresas : UserControl
    {
        public UCEmpresas()
        {
            InitializeComponent();
        }

        private void empresasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


        }

        private void UCEmpresas_Load(object sender, EventArgs e)
        {
            tipo_empresasTableAdapter.Fill(dBTransporte.tipo_empresas);
            empresasTableAdapter.Fill(dBTransporte.empresas);
            estado(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            empresasBindingSource.AddNew();
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

            empresasBindingSource.RemoveAt(empresasBindingSource.Position);
            this.tableAdapterManager.UpdateAll(this.dBTransporte);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.empresasBindingSource.CancelEdit();
            estado(false);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (codigoTextBox.Text == "")
            {
                errorProvider1.SetError(codigoTextBox, "El campo codigo esta vacía");
                codigoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (nombreTextBox.Text == "")
            {
                errorProvider1.SetError(nombreTextBox, "El campo nombre esta vacía");
                nombreTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (gerenteTextBox.Text == "")
            {
                errorProvider1.SetError(gerenteTextBox, "El campo gerente esta vacía");
                gerenteTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (propietarioTextBox.Text == "")
            {
                errorProvider1.SetError(propietarioTextBox, "El campo propietario esta vacía");
                propietarioTextBox.Focus();
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
            if (direccionTextBox.Text == "")
            {
                errorProvider1.SetError(direccionTextBox, "El campo direccion esta vacía");
                direccionTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (ciudadTextBox.Text == "")
            {
                errorProvider1.SetError(ciudadTextBox, "El campo ciudad esta vacía");
                ciudadTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            this.Validate();
            this.empresasBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dBTransporte);
            estado(false);
        }

        private void telefonoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validator.isNumber(e);
        }
    }
}
