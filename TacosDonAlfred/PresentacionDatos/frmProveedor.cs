﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using ManejadorTacos;

namespace PresentacionDatos
{
    public partial class frmProveedor : Form
    {
        ManejadorProveedor mp;
        EntidadUsuarios eu = new EntidadUsuarios("", "", "", "", "", "");
        EntidadProveedor ep = new EntidadProveedor(0, "");
        int fila = 0;
        string r = "";
        public frmProveedor()
        {
            InitializeComponent();
            mp = new ManejadorProveedor();
            Actualizar();
        }
        void Actualizar()
        {
            dtgProveedores.DataSource = mp.Mostrar(txtNombre.Text).Tables[0];
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            ep.IdProveedor = int.Parse(dtgProveedores.Rows[fila].Cells[0].Value.ToString());
            ep.RFC = dtgProveedores.Rows[fila].Cells[1].Value.ToString();
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtgProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            eu.idUsuario = dtgProveedores.Rows[fila].Cells[0].Value.ToString();
            eu.Nombre = dtgProveedores.Rows[fila].Cells[1].Value.ToString();
            eu.ApellidoPaterno = dtgProveedores.Rows[fila].Cells[2].Value.ToString();
            eu.ApellidoMaterno = dtgProveedores.Rows[fila].Cells[3].Value.ToString();
            eu.Telefono = dtgProveedores.Rows[fila].Cells[4].Value.ToString();
            eu.Domicilio = dtgProveedores.Rows[fila].Cells[5].Value.ToString();
            ep.RFC = dtgProveedores.Rows[fila].Cells[6].Value.ToString();
            ep.IdProveedor = int.Parse(dtgProveedores.Rows[fila].Cells[0].Value.ToString());
        }

        private void btnInsertar_Click_1(object sender, EventArgs e)
        {
            frmProveedorAdd fp = new frmProveedorAdd();
            fp.ShowDialog();
            Actualizar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmProveedorAdd fpa = new frmProveedorAdd(ep, eu);
            fpa.ShowDialog();
            Actualizar();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Atencion esta seguro de borrar el usuario? " + eu.Nombre + " " + eu.ApellidoPaterno, "!Atencion", MessageBoxButtons.YesNo);
            if (rs == DialogResult.Yes)
            {
                r = mp.EliminarProveedor(ep);
                r = mp.EliminarUsuario(eu);
                Actualizar();
            }
        }
    }
}
