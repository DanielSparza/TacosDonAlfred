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
    public partial class FrmCompras : Form
    {
        ManejadorCompras mc;
        public static EntidadCompras entidadCompras = new EntidadCompras(0, " ", 0.0, 0.0, 0, 0);
        int fila = 0;
        string r = "";
        string proveedor = "";
        string producto = "";
        public FrmCompras()
        {
            InitializeComponent();
            mc = new ManejadorCompras();
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            Actualizar("");
        }

        void Actualizar(string buscar)
        {
            
            Compritas.DataSource = mc.Mostrar(buscar).Tables[0];


        }
        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            FrmComprasADD fc = new FrmComprasADD(entidadCompras, proveedor, producto);
            fc.ShowDialog();
            Actualizar("");
        }

        private void dtgcompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            entidadCompras.IdCompra = int.Parse(Compritas.Rows[fila].Cells[0].Value.ToString());
            entidadCompras.Fecha = (Compritas.Rows[fila].Cells[1].Value.ToString());
            entidadCompras.Cantidad = double.Parse(Compritas.Rows[fila].Cells[2].Value.ToString());
            entidadCompras.Precio = double.Parse(Compritas.Rows[fila].Cells[3].Value.ToString());
            proveedor = Compritas.Rows[fila].Cells[4].Value.ToString();
            producto = Compritas.Rows[fila].Cells[5].Value.ToString();

            MessageBox.Show(entidadCompras.IdCompra.ToString());
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Eliminar esta compra" + entidadCompras.Fecha, "Seguro", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = mc.EliminarCompra(entidadCompras);
                Actualizar("");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Actualizar(txtBuscar.Text);
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            FrmComprasADD fp = new FrmComprasADD();
            fp.ShowDialog();
            Actualizar("");
        }

        private void compritas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            entidadCompras.IdCompra = int.Parse(Compritas.Rows[fila].Cells[0].Value.ToString());
            entidadCompras.Fecha = (Compritas.Rows[fila].Cells[1].Value.ToString());
            entidadCompras.Cantidad = double.Parse(Compritas.Rows[fila].Cells[2].Value.ToString());
            entidadCompras.Precio = double.Parse(Compritas.Rows[fila].Cells[3].Value.ToString());
            proveedor = Compritas.Rows[fila].Cells[4].Value.ToString();
            producto = Compritas.Rows[fila].Cells[5].Value.ToString();

            MessageBox.Show(entidadCompras.IdCompra.ToString());
        }
    }
}