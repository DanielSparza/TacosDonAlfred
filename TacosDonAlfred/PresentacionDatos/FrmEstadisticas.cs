using System;
using System.Drawing;
using System.Windows.Forms;
using ManejadorTacos;
using System.Windows.Forms.DataVisualization.Charting;

namespace PresentacionDatos
{
    public partial class FrmEstadisticas : Form
    {
        ManejadorEstadisticas me;

        public FrmEstadisticas()
        {
            InitializeComponent();
            me = new ManejadorEstadisticas();
            Actualizar();
        }

        private void PtbRegresar_Click(object sender, EventArgs e)
        {
            Close();
            frmPrincipal.v = 0;
        }

        public void Actualizar()
        {
            GraficarGastos();
            GraficarVentas();
            GraficarAlmacen();

            if (cmbGraficas.Text == "Gastos")
            {
                panelInventario.Visible = false;
                panelVentas.Visible = false;
                panelGastos.Visible = true;
                lblGastosTotales.Text = "$ " + me.obtenerTotalGastos(dtpFechaInicio.Text, dtpFechaFinal.Text);
            }
            else if (cmbGraficas.Text == "Ventas")
            {
                panelGastos.Visible = false;
                panelInventario.Visible = false;
                panelVentas.Visible = true;
                lblTotalVentas.Text = "$ " + me.obtenerTotalVentas(dtpFechaInicio.Text, dtpFechaFinal.Text);
            }
            else if (cmbGraficas.Text == "Inventario")
            {
                panelGastos.Visible = false;
                panelVentas.Visible = false;
                panelInventario.Visible = true;
            }
            else
            {
                panelGastos.Visible = false;
                panelVentas.Visible = false;
                panelInventario.Visible = false;
            }
        }

        public void GraficarGastos()
        {
            chartGastos.Titles.Clear();
            chartGastos.Series.Clear();
            chartGastos.ChartAreas.Clear();
            chartGastos.Palette = ChartColorPalette.Excel;

            ChartArea area = new ChartArea();
            //area.Area3DStyle.Enable3D = true;
            chartGastos.ChartAreas.Add(area);

            Title titulo = new Title("Gastos");
            titulo.Font = new Font("Arial", 14, FontStyle.Bold);
            chartGastos.Titles.Add(titulo);

            Series serie = new Series("Productos");
            serie.ChartType = SeriesChartType.Bar;
            serie.XValueMember = "Producto";
            serie.YValueMembers = "Gasto";
            serie.Font = new Font("Arial", 12, FontStyle.Regular);
            serie.Color = Color.Orange;
            serie.IsValueShownAsLabel = true;
            chartGastos.Series.Add(serie);

            chartGastos.DataSource = me.MostrarGastos(dtpFechaInicio.Text, dtpFechaFinal.Text);
        }

        public void GraficarVentas()
        {
            chartVentas.Titles.Clear();
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Palette = ChartColorPalette.Excel;

            ChartArea area = new ChartArea();
            //area.Area3DStyle.Enable3D = true;
            chartVentas.ChartAreas.Add(area);

            Title titulo = new Title("Ventas");
            titulo.Font = new Font("Arial", 14, FontStyle.Bold);
            chartVentas.Titles.Add(titulo);

            Series serie = new Series("Platillos");
            serie.ChartType = SeriesChartType.Bar;
            serie.XValueMember = "Producto";
            serie.YValueMembers = "Total";
            serie.Font = new Font("Arial", 12, FontStyle.Regular);
            serie.Color = Color.LightGreen;
            serie.IsValueShownAsLabel = true;
            chartVentas.Series.Add(serie);

            chartVentas.DataSource = me.MostrarVentas(dtpFechaInicio.Text, dtpFechaFinal.Text);
        }

        public void GraficarAlmacen()
        {
            chartAlmacen.Titles.Clear();
            chartAlmacen.Series.Clear();
            chartAlmacen.ChartAreas.Clear();
            chartAlmacen.Palette = ChartColorPalette.Excel;

            ChartArea area = new ChartArea();
            area.Area3DStyle.Enable3D = true;
            chartAlmacen.ChartAreas.Add(area);

            Title titulo = new Title("Almacen");
            titulo.Font = new Font("Arial", 14, FontStyle.Bold);
            chartAlmacen.Titles.Add(titulo);

            Series serie = new Series("Productos");
            serie.ChartType = SeriesChartType.Doughnut;
            serie.XValueMember = "Producto";
            serie.YValueMembers = "Cantidad Existente";
            serie.Font = new Font("Arial", 12, FontStyle.Regular);
            serie.LabelForeColor = Color.Black;
            serie.IsValueShownAsLabel = true;
            chartAlmacen.Series.Add(serie);

            chartAlmacen.DataSource = me.MostrarAlmacen(cmbGraficas.Text);
        }

        private void cmbGraficas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
    }
}
