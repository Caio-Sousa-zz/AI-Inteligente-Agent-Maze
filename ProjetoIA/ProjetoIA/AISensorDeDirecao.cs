using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ProjetoIA
{
    public partial class AISensorDeDirecao : Form
    {
        public AISensorDeDirecao()
        {
            InitializeComponent();
        }

        #region Variaveis e Objetos Globais

        // Constantes
        const int comprimentoColunas = 30; // Representa tamanho de colunas
                                           // Objetos de referente a DtgMapa
        DataGridViewImageColumn Coluna1;
        DataGridViewImageColumn Coluna2;
        DataGridViewImageColumn Coluna3;
        DataGridViewImageColumn Coluna4;
        DataGridViewImageColumn Coluna5;
        DataGridViewImageColumn Coluna6;
        DataGridViewImageColumn Coluna7;
        DataGridViewImageColumn Coluna8;
        Bitmap imagemColuna;
        // Caminho Imagens
        string caminhoDaImagemParede = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "preto.png");
        string caminhoDaImagemMonstro = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "monstro.png");
        string caminhoDaImagemLivre = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "livree.png");
        string caminhoDaImagemElemento = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "Teste.png");
        string caminhoDaImagemEstadoFinal = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "Final.png");
        //Identificadores 
        const int ID_PAREDE = -1;
        const int ID_CAMINHO_LIVRE = 1;
        const int ID_MOSNTRO = 2;
        const int ID_ELEMENTO = 3;
        const int ID_CAMINHO_ANDADO = 4;
        //Objetos e variaveis do jogo
        SensorDirecao CaminhoSensorAtual;
        short vida = 2;
        int estadoFinal = 0;
        Queue filaDaSolucao;
        // Funcao randomica
        Random randomica;
        // Local do elemento
        int linhaElemento = -1;
        int colunaElemento = -1;
        //Armazenamento de conhecimento local
        DataTable dtConsultaConhecimento;

        #endregion

        #region Enumerador

        enum inicioDoMapa
        {
            linha = 3,
            coluna = 0
        };
        enum fimDoMapa
        {
            linha = 8,
            coluna = 8
        };
        enum SensorDirecao
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }

        #endregion

        #region Eventos

        private void AISensorDeDirecao_Load(object sender, EventArgs e)
        {
            try
            {
                this.filaDaSolucao = new Queue();
                this.configuraDtg();
                this.criaColunasELinhaDTGMapa();
                this.criaMapaRandomico();
                this.configuraNovoJogo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnProximoPasso_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtgSolucao.ClearSelection();
                this.proximoPasso();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnM1_Click(object sender, EventArgs e)
        {

            this.criaMapa1();
            this.configuraNovoJogo();
        }
        private void btnM2_Click(object sender, EventArgs e)
        {

            this.criaMapa2();
            this.configuraNovoJogo();
        }
        private void btnM3_Click(object sender, EventArgs e)
        {

            this.criaMapa3();
            this.configuraNovoJogo();
        }
        private void btnM4_Click(object sender, EventArgs e)
        {

            this.criaMapa4();
            this.configuraNovoJogo();
        }
        private void btnRandomMap_Click(object sender, EventArgs e)
        {


            this.criaMapaRandomico();
            this.configuraNovoJogo();
        }
        private void btnConhecimento_Click(object sender, EventArgs e)
        {
            if (this.dtConsultaConhecimento == null)
            {
                MessageBox.Show("Nao existe Solução armazenada‎ para este mapa",
                                 this.Text);
            }
            else if (this.dtConsultaConhecimento.Rows.Count == 0)
            {
                MessageBox.Show("Nao existe Solução armazenada ‎para este mapa",
                                this.Text);
            }
            else
            {
                this.reininciaMapaAtual();
                this.setCaminhoComConhecimento(this.dtConsultaConhecimento.Rows[0][2].ToString());
            }
        }

        #endregion

        #region Metodos

        private void configuraDtg()
        {
            this.DtgMapa.ColumnHeadersVisible = false;
            this.DtgMapa.RowHeadersVisible = false;
            this.DtgMapa.Height = 180;
            this.DtgMapa.Width = 243;
        }
        private void criaColunasELinhaDTGMapa()
        {
            // Coluna 1
            this.Coluna1 = new DataGridViewImageColumn();
            this.Coluna1.Name = "C1"; // Set Nome
            this.Coluna1.HeaderText = "C1"; // Nome do cabecalho
            this.Coluna1.Width = comprimentoColunas;
            this.Coluna1.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna1);
            // Coluna 2
            this.Coluna2 = new DataGridViewImageColumn();
            this.Coluna2.Name = "C2"; // Set Nome
            this.Coluna2.HeaderText = "C2"; // Nome do cabecalho
            this.Coluna2.Width = comprimentoColunas;
            this.Coluna2.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna2);
            // Coluna 3
            this.Coluna3 = new DataGridViewImageColumn();
            this.Coluna3.Name = "C3"; // Set Nome
            this.Coluna3.HeaderText = "C3"; // Nome do cabecalho
            this.Coluna3.Width = comprimentoColunas;
            this.Coluna3.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna3);
            // Coluna 4
            this.Coluna4 = new DataGridViewImageColumn();
            this.Coluna4.Name = "C4"; // Set Nome
            this.Coluna4.HeaderText = "C4"; // Nome do cabecalho
            this.Coluna4.ReadOnly = true;
            this.Coluna4.Width = comprimentoColunas;
            this.DtgMapa.Columns.Add(this.Coluna4);
            // Coluna 5
            this.Coluna5 = new DataGridViewImageColumn();
            this.Coluna5.Name = "C5"; // Set Nome
            this.Coluna5.HeaderText = "C5"; // Nome do cabecalho
            this.Coluna5.Width = comprimentoColunas;
            this.Coluna5.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna5);
            // Coluna 6
            this.Coluna6 = new DataGridViewImageColumn();
            this.Coluna6.Name = "C6"; // Set Nome
            this.Coluna6.HeaderText = "C6"; // Nome do cabecalho
            this.Coluna6.Width = comprimentoColunas;
            this.Coluna6.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna6);
            // Coluna 7
            this.Coluna7 = new DataGridViewImageColumn();
            this.Coluna7.Name = "C7"; // Set Nome
            this.Coluna7.HeaderText = "C7"; // Nome do cabecalho
            this.Coluna7.Width = comprimentoColunas;
            this.Coluna7.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna7);
            // Coluna 8
            this.Coluna8 = new DataGridViewImageColumn();
            this.Coluna8.Name = "C8"; // Set Nome
            this.Coluna8.HeaderText = "C8"; // Nome do cabecalho
            this.Coluna8.Width = comprimentoColunas;
            this.Coluna8.ReadOnly = true;
            this.DtgMapa.Columns.Add(this.Coluna8);

            // Add Linhas Mapa 8x8
            for (int i = 0; i < 8; i++)
                this.DtgMapa.Rows.Add();
        }
        private void criaMapa1()
        {
            this.estadoFinal = 12;
            this.limpaDtg();
            this.verificaMapaSelecionado(1);
            // Configura Parede
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    #region Paredes
                    // Set Paredes
                    this.imagemColuna = new Bitmap(caminhoDaImagemParede);

                    if (linha == 0)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 1 &&
                            (coluna != 2 || coluna != 5))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 2 &&
                            (coluna == 0 || coluna == 1 || coluna == 6 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 3 &&
                        (coluna == 3 || coluna == 4 || coluna == 6 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 4 &&
                        (coluna != 3 && coluna != 4 && coluna != 5))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 5 &&
                        (coluna != 1 && coluna != 3))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 6 &&
                            (coluna == 0))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 7 && (coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    #endregion
                    #region Monstro
                    // Set  monstro
                    this.imagemColuna = new Bitmap(caminhoDaImagemMonstro);
                    if (linha == 1 && (coluna == 2 || coluna == 5))
                    {
                        if (coluna == 2)
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "3"; // Estado do automato
                        else
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "5"; // Estado do automato

                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                    }
                    else if (linha == 5 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "10"; // Estado do automato
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                    }
                    #endregion
                    #region Caminho
                    // Set caminho
                    this.imagemColuna = new Bitmap(caminhoDaImagemLivre);
                    if (linha == 2 &&
                       (coluna != 0 && coluna != 1 && coluna != 6 && coluna != 7))
                    {
                        if (coluna == 2)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "2"; // Estado do automato
                        }
                        else if (coluna == 5)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "4"; // Estado do automato
                        }

                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 3 &&
                            (coluna != 3 && coluna != 4 && coluna != 6 && coluna != 7))
                    {
                        if (coluna == 0)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "0"; // Estado do automato
                            this.setImagem(linha, coluna, caminhoDaImagemElemento); // estado inicial
                        }
                        else if (coluna == 2)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "1"; // Estado do automato
                        }

                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 4 &&
                        (coluna != 0 && coluna != 1 &&
                         coluna != 2 && coluna != 6 && coluna != 7))
                    {

                        if (coluna == 5)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "6"; // Estado do automato
                        }
                        else if (coluna == 3)
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "7"; // Estado do automato
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 5 && coluna == 3)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 6 && coluna != 0)
                    {
                        if (coluna == 1)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "9"; // Estado do automato
                        }
                        else if (coluna == 3)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "8"; // Estado do automato
                        }
                        else if (coluna == 7)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "11"; // Estado do automato
                        }
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 7 && coluna == 7)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "12"; // Estado do automato
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.setImagem(linha,
                                       coluna,
                                       caminhoDaImagemEstadoFinal); // estado Final
                    }
                }
            }
            #endregion
        }
        private void criaMapa2()
        {
            this.estadoFinal = 12;
            this.limpaDtg();
            this.verificaMapaSelecionado(2);
            // Configura Parede
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    #region Parede
                    // Set Paredes
                    this.imagemColuna = new Bitmap(caminhoDaImagemParede);

                    if (linha == 0 && coluna != 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 1 &&
                            (coluna == 0 ||
                             coluna == 2 ||
                             coluna == 3))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 2 &&
                            (coluna == 0 ||
                             coluna == 5 ||
                             coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 3 && coluna != 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 4 &&
                            (coluna == 0 ||
                             coluna == 1 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 5 && (coluna != 2))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 6 &&
                            (coluna == 0 ||
                             coluna == 1 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 7 && coluna != 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    #endregion
                    #region Mosntro
                    this.imagemColuna = new Bitmap(caminhoDaImagemMonstro);

                    if (linha == 1 && coluna == 7)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "5";// Estado do automato
                    }
                    else if (linha == 5 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "9";// Estado do automato
                    }
                    else if (linha == 5 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "7";// Estado do automato
                    }
                    #endregion
                    #region Caminho Livre
                    this.imagemColuna = new Bitmap(caminhoDaImagemLivre);

                    if (linha == 0 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "0";// Estado do automato
                        this.setImagem(linha, coluna, caminhoDaImagemElemento); // estado inicial
                    }
                    else if (linha == 1 &&
                            (coluna == 1 || coluna == 4 ||
                             coluna == 5 || coluna == 6))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;

                        switch (coluna)
                        {
                            case 4:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "3";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "4";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 2 &&
                            (coluna != 0 && coluna != 5 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 1:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "1";// Estado do automato
                                break;
                            case 4:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "2";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 3 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 4 && (coluna != 0 && coluna != 1 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 2:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "8";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "6";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 5 && coluna == 2)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 6 && (coluna != 0 && coluna != 1 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 2:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "10";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "11";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 7 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "12";// Estado do automato
                        this.setImagem(linha,
                                       coluna,
                                       caminhoDaImagemEstadoFinal); // estado Final
                    }
                    #endregion
                }
            }
        }
        private void criaMapa3()
        {
            this.estadoFinal = 11;
            this.limpaDtg();
            this.verificaMapaSelecionado(3);
            // Configura Parede
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    #region Parede
                    // Set Paredes
                    this.imagemColuna = new Bitmap(caminhoDaImagemParede);

                    if (linha == 0 && coluna != 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 1 &&
                            (coluna == 0 ||
                             coluna == 2 ||
                             coluna == 3 ||
                             coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 2 &&
                            (coluna == 0 ||
                             coluna == 5 ||
                             coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 3 && coluna != 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 4 &&
                            (coluna == 0 ||
                             coluna == 1 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 5 && (coluna != 2))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 6 &&
                            (coluna == 0 ||
                             coluna == 1 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 7 && coluna != 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    #endregion
                    #region Mosntro
                    this.imagemColuna = new Bitmap(caminhoDaImagemMonstro);

                    if (linha == 5 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "8";// Estado do automato
                    }
                    else if (linha == 4 && coluna == 7)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "6";// Estado do automato
                    }
                    #endregion
                    #region Caminho Livre
                    this.imagemColuna = new Bitmap(caminhoDaImagemLivre);

                    if (linha == 0 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "0";// Estado do automato
                        this.setImagem(linha, coluna, caminhoDaImagemElemento); // estado inicial
                    }
                    else if (linha == 1 &&
                            (coluna == 1 || coluna == 4 ||
                             coluna == 5 || coluna == 6))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;

                        switch (coluna)
                        {
                            case 4:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "3";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "4";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 2 &&
                            (coluna != 0 && coluna != 5 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 1:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "1";// Estado do automato
                                break;
                            case 4:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "2";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 3 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 4 && (coluna != 0 && coluna != 1 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 2:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "7";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "5";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 5 && coluna == 2)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 6 && (coluna != 0 && coluna != 1 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 2:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "9";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "10";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 7 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "11";// Estado do automato
                        this.setImagem(linha,
                                       coluna,
                                       caminhoDaImagemEstadoFinal); // estado Final
                    }
                    #endregion
                }
            }
        }
        private void criaMapa4()
        {
            this.estadoFinal = 14;
            this.limpaDtg();
            this.verificaMapaSelecionado(4);
            // Configura Parede
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    #region Parede
                    // Set Paredes
                    this.imagemColuna = new Bitmap(caminhoDaImagemParede);

                    if (linha == 0 && coluna != 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 1 && coluna != 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 3 && (coluna != 6 && coluna != 1))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 4 &&
                             coluna == 7)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 5 && (coluna != 1 && coluna != 6))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    else if (linha == 7 && coluna != 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_PAREDE;
                    }
                    #endregion
                    #region Mosntro
                    this.imagemColuna = new Bitmap(caminhoDaImagemMonstro);

                    if (linha == 2 && (coluna == 0 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        if (coluna == 7)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "5";// Estado do automato
                            this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        }
                        else if (coluna == 0)
                        {
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "2";// Estado do automato
                            this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        }
                    }
                    else if (linha == 3 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "3";// Estado do automato
                    }
                    else if (linha == 4 && coluna == 0)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "9";// Estado do automato
                    }
                    else if (linha == 5 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "7";// Estado do automato
                    }
                    else if (linha == 6 && (coluna == 0 || coluna == 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_MOSNTRO;
                        if (coluna == 0)
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "11";// Estado do automato
                        else if (coluna == 7)
                            this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "13";// Estado do automato
                    }
                    #endregion
                    #region Caminho Livre
                    this.imagemColuna = new Bitmap(caminhoDaImagemLivre);

                    if (linha == 0 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "0";// Estado do automato
                        this.setImagem(linha, coluna, caminhoDaImagemElemento); // estado inicial
                    }
                    else if (linha == 1 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 2 && (coluna != 0 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 1:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "1";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "4";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 3 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 4 && (coluna != 0 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 1:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "8";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "6";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 5 && coluna == 1)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                    }
                    else if (linha == 6 && (coluna != 0 && coluna != 7))
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        switch (coluna)
                        {
                            case 1:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "10";// Estado do automato
                                break;
                            case 6:
                                this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "12";// Estado do automato
                                break;
                        }
                    }
                    else if (linha == 7 && coluna == 6)
                    {
                        this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
                        this.DtgMapa.Rows[linha].Cells[coluna].Tag = ID_CAMINHO_LIVRE;
                        this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText = "14";// Estado do automato
                        this.setImagem(linha,
                                       coluna,
                                       caminhoDaImagemEstadoFinal); // estado Final
                    }
                    #endregion
                }
            }

        }
        private void criaMapaRandomico()
        {
            this.randomica = new Random();
            int random = this.randomica.Next(1, 5);
            this.limpaDtg();
            switch (random)
            {
                case 1:
                    this.criaMapa1();
                    break;
                case 2:
                    this.criaMapa2();
                    break;
                case 3:
                    this.criaMapa3();
                    break;
                case 4:
                    this.criaMapa4();
                    break;
            }
        }
        private void verificaMapaSelecionado(int numeroMapa)
        {
            Color ativado = Color.Black;
            Color desativado = Color.White;
            this.btnM1.ForeColor = desativado;
            this.btnM2.ForeColor = desativado;
            this.btnM3.ForeColor = desativado;
            this.btnM4.ForeColor = desativado;
            switch (numeroMapa)
            {

                case 1:
                    this.btnM1.ForeColor = ativado;
                    break;
                case 2:
                    this.btnM2.ForeColor = ativado;
                    break;
                case 3:
                    this.btnM3.ForeColor = ativado;
                    break;
                case 4:
                    this.btnM4.ForeColor = ativado;
                    break;
            }
        }
        private void limpaDtg()
        {
            this.inicializaLinhaEColuna();
            this.DtgMapa.Columns.Clear();
            this.DtgMapa.Rows.Clear();
            this.criaColunasELinhaDTGMapa();
        }
        private void inicializaLinhaEColuna()
        {
            this.linhaElemento = -1;
            this.colunaElemento = -1;
        }
        private void configuraNovoJogo()
        {
            this.atualizaListaDaSolucao();
            this.filaDaSolucao = new Queue();
            this.CaminhoSensorAtual = SensorDirecao.North;
            this.btnEast.ForeColor = Color.White;
            this.btnSouth.ForeColor = Color.White;
            this.btnWest.ForeColor = Color.White;
            this.btnNorth.ForeColor = Color.Black;
            this.vida = 2;
            this.lblQtdVidas.Text = vida.ToString();
        }
        private void setImagem(int linha, int coluna, string imagem)
        {
            this.imagemColuna = new Bitmap(imagem);

            this.DtgMapa.Update();
            this.DtgMapa.Rows[linha].Cells[coluna].Value = this.imagemColuna;
            this.DtgMapa.Refresh();
        }
        private void proximoPasso()
        {
            if (linhaElemento == -1 &&
                colunaElemento == -1)
            {
                this.setCaminhoParaAndar(this.obtenhaColunaEstadoInicial(),
                                         this.obtenhaLinhaEstadoInicial());

            }
            else
            {
                this.setCaminhoParaAndar(this.colunaElemento,
                                         this.linhaElemento);
            }
        }
        private void configuraCompass()
        {
            Color corPadrao = Color.White;
            Color corDirecaoAtual = Color.Black;

            this.btnEast.ForeColor = corPadrao;
            this.btnNorth.ForeColor = corPadrao;
            this.btnSouth.ForeColor = corPadrao;
            this.btnWest.ForeColor = corPadrao;

            if (this.CaminhoSensorAtual == SensorDirecao.North)
            {
                this.btnEast.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.East;
            }
            else if (this.CaminhoSensorAtual == SensorDirecao.East)
            {
                this.btnSouth.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.South;
            }
            else if (this.CaminhoSensorAtual == SensorDirecao.South)
            {
                this.btnWest.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.West;
            }
            else if (this.CaminhoSensorAtual == SensorDirecao.West)
            {
                this.btnNorth.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.North;
            }
        }
        private void configuraCompass(SensorDirecao sensor)
        {
            Color corPadrao = Color.White;
            Color corDirecaoAtual = Color.Black;

            this.btnEast.ForeColor = corPadrao;
            this.btnNorth.ForeColor = corPadrao;
            this.btnSouth.ForeColor = corPadrao;
            this.btnWest.ForeColor = corPadrao;

            if (sensor == SensorDirecao.North)
            {
                this.btnEast.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.East;
            }
            else if (sensor == SensorDirecao.East)
            {
                this.btnSouth.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.South;
            }
            else if (sensor == SensorDirecao.South)
            {
                this.btnWest.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.West;
            }
            else if (sensor == SensorDirecao.West)
            {
                this.btnNorth.ForeColor = corDirecaoAtual;
                this.CaminhoSensorAtual = SensorDirecao.North;
            }
        }
        private void setCaminhoParaAndar(int colunaAtual, int linhaAtual)
        {
            this.setVida(this.vida);
            bool achouProximoEstado = false;

            do
            {
                #region SensorNorte
                if (this.CaminhoSensorAtual == SensorDirecao.North)
                {
                    --linhaAtual;

                    // Fora do mapa
                    if (linhaAtual > 7 || linhaAtual < 0 ||
                         colunaAtual > 7 || colunaAtual < 0)
                    {
                        this.configuraCompass();
                        linhaAtual++;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_CAMINHO_LIVRE)
                    {
                        if (this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].ToolTipText != "")
                        {
                            this.filaDaSolucao.Enqueue("N");
                            achouProximoEstado = true;
                        }

                        this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag = ID_ELEMENTO;

                        this.setImagem((linhaAtual),
                                       (colunaAtual),
                                       caminhoDaImagemElemento);
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_PAREDE)
                    {
                        this.configuraCompass();
                        linhaAtual++;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_MOSNTRO)
                    {
                        this.setVida(--this.vida);
                        this.configuraCompass();
                        linhaAtual++;
                        achouProximoEstado = true;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_ELEMENTO)
                    {
                        this.configuraCompass();
                        linhaAtual++;
                    }
                }
                #endregion
                #region SensorEast
                else if (this.CaminhoSensorAtual == SensorDirecao.East)
                {
                    ++colunaAtual;
                    // Fora do mapa
                    if (linhaAtual > 7 || linhaAtual < 0 ||
                        colunaAtual > 7 || colunaAtual < 0)
                    {
                        this.configuraCompass();
                        colunaAtual--;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_CAMINHO_LIVRE)
                    {
                        if (this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].ToolTipText != "")
                        {
                            this.filaDaSolucao.Enqueue("E");
                            achouProximoEstado = true;
                        }
                        this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag = ID_ELEMENTO;

                        this.setImagem((linhaAtual),
                                       (colunaAtual),
                                       caminhoDaImagemElemento);
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_PAREDE)
                    {
                        this.configuraCompass();
                        colunaAtual--;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_MOSNTRO)
                    {
                        this.configuraCompass();
                        colunaAtual--;
                        this.setVida(--this.vida);
                        achouProximoEstado = true;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_ELEMENTO)
                    {
                        this.configuraCompass();
                        colunaAtual--;
                    }
                }
                #endregion
                #region SensorSouth
                else if (this.CaminhoSensorAtual == SensorDirecao.South)
                {
                    ++linhaAtual;
                    // Fora do mapa
                    if (linhaAtual > 7 || linhaAtual < 0 ||
                        colunaAtual > 7 || colunaAtual < 0)
                    {
                        this.configuraCompass();
                        linhaAtual--;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_CAMINHO_LIVRE)
                    {
                        if (this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].ToolTipText != "")
                        {
                            this.filaDaSolucao.Enqueue("S");
                            achouProximoEstado = true;
                        }

                        this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag = ID_ELEMENTO;

                        this.setImagem((linhaAtual),
                                       (colunaAtual),
                                       caminhoDaImagemElemento);
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_PAREDE)
                    {
                        this.configuraCompass();
                        linhaAtual--;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_MOSNTRO)
                    {
                        this.setVida(--this.vida);
                        linhaAtual--;
                        this.configuraCompass();
                        achouProximoEstado = true;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_ELEMENTO)
                    {
                        this.configuraCompass();
                        linhaAtual--;
                    }
                }
                #endregion
                #region SensorWest
                else if (this.CaminhoSensorAtual == SensorDirecao.West)
                {
                    --colunaAtual;
                    // Fora do mapa
                    if (linhaAtual > 7 || linhaAtual < 0 ||
                        colunaAtual > 7 || colunaAtual < 0)
                    {
                        this.configuraCompass();
                        colunaAtual++;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_CAMINHO_LIVRE)
                    {
                        if (this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].ToolTipText != "")
                        {
                            this.filaDaSolucao.Enqueue("W");
                            achouProximoEstado = true;
                        }
                        this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag = ID_ELEMENTO;

                        this.setImagem((linhaAtual),
                                       (colunaAtual),
                                       caminhoDaImagemElemento);
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_PAREDE)
                    {
                        this.configuraCompass();
                        colunaAtual++;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_MOSNTRO)
                    {
                        this.setVida(--this.vida);
                        colunaAtual++;
                        this.configuraCompass();
                        achouProximoEstado = true;
                    }
                    else if ((int)this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].Tag == ID_ELEMENTO)
                    {
                        this.configuraCompass();
                        colunaAtual++;
                    }
                }
                #endregion
            } while (achouProximoEstado == false && vida != 0);
            System.Threading.Thread.Sleep(100);

            if (vida == 0)
            {
                linhaElemento = -1;
                colunaElemento = -1;
                MessageBox.Show("GAME OVER",
                                 this.Text);
                this.reininciaMapaAtual();
            }
            else
            {
                linhaElemento = linhaAtual;
                colunaElemento = colunaAtual;
            }

            if (this.DtgMapa.Rows[linhaAtual].Cells[colunaAtual].ToolTipText == estadoFinal.ToString())
            {
                StringBuilder caminhoValido = new StringBuilder();
                foreach (Object obj in filaDaSolucao)
                    caminhoValido.Append(obj.ToString());

                DataTable dtConsultaSolucao = Persistencia.consultaRegistros(obtenhaIDMapa());

                if (dtConsultaSolucao.Rows.Count == 0)
                {
                    MessageBox.Show("Sucesso" + Environment.NewLine +
                                    "Solução : " + caminhoValido.ToString() + Environment.NewLine +
                                    "Gravada com sucesso!",
                                    this.Text);
                    Persistencia.gravaNovoRegistro(obtenhaIDMapa(),
                                                   caminhoValido.ToString());
                }
                else
                {
                    MessageBox.Show("Sucesso",
                                    this.Text,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                this.reininciaMapaAtual();
            }
        }
        private void setVida(short vidas)
        {
            this.vida = vidas;
            this.lblQtdVidas.Text = this.vida.ToString();
        }
        private int obtenhaLinhaEstadoInicial()
        {
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    if (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText.Equals("0"))
                        return linha;
                }
            }
            MessageBox.Show("Falha ao obter linha inicial", this.Text);
            return 0;
        }
        private int obtenhaColunaEstadoInicial()
        {
            for (int linha = 0; linha < 8; linha++)
            {
                for (int coluna = 0; coluna < 8; coluna++)
                {
                    if (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText.Equals("0"))
                        return coluna;
                }
            }
            MessageBox.Show("Falha ao obter coluna estado inicial", this.Text);
            return 0;
        }
        private int obtenhaIDMapa()
        {
            if (this.btnM1.ForeColor == Color.Black)
            {
                return 1;
            }
            else if (this.btnM2.ForeColor == Color.Black)
            {
                return 2;
            }
            else if (this.btnM3.ForeColor == Color.Black)
            {
                return 3;
            }
            else if (this.btnM4.ForeColor == Color.Black)
            {
                return 4;
            }
            else
            {
                throw new Exception("Falha ao obter ID do MAPA");
            }
        }
        private void reininciaMapaAtual()
        {
            this.configuraNovoJogo();
            switch (this.obtenhaIDMapa())
            {
                case 1:
                    this.criaMapa1();
                    break;
                case 2:
                    this.criaMapa2();
                    break;
                case 3:
                    this.criaMapa3();
                    break;
                case 4:
                    this.criaMapa4();
                    break;
            }
        }
        private void setCaminhoComConhecimento(string conhecimento)
        {
            int linha = obtenhaLinhaEstadoInicial();
            int coluna = obtenhaColunaEstadoInicial();

            foreach (char direcao in conhecimento)
            {
                switch (direcao)
                {
                    case 'N':
                        linha--;
                        while (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText == "")
                        {
                            setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                            System.Threading.Thread.Sleep(1000);
                            linha--;
                        }
                        setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                        break;
                    case 'E':
                        coluna++;
                        while (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText == "")
                        {

                            setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                            System.Threading.Thread.Sleep(1000);
                            coluna++;
                        }
                        setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                        break;
                    case 'S':
                        linha++;
                        while (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText == "")
                        {

                            setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                            System.Threading.Thread.Sleep(1000);
                            linha++;
                        }
                        setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                        break;
                    case 'W':
                        coluna--;
                        while (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText == "")
                        {

                            setImagem(linha,
                                      coluna,
                                       caminhoDaImagemElemento);
                            System.Threading.Thread.Sleep(1000);
                            coluna--;
                        }
                        setImagem(linha,
                                       coluna,
                                       caminhoDaImagemElemento);
                        break;
                }
            }
            if (this.DtgMapa.Rows[linha].Cells[coluna].ToolTipText == estadoFinal.ToString())
            {
                MessageBox.Show("Sucesso", this.Text);
                this.reininciaMapaAtual();
            }

        }
        private void atualizaListaDaSolucao()
        {
            dtConsultaConhecimento = Persistencia.consultaRegistros(obtenhaIDMapa());

            if (dtConsultaConhecimento.Rows.Count != 0)
            {
                this.dtgSolucao.DataSource = dtConsultaConhecimento;
                this.dtgSolucao.AutoResizeColumns();
                this.dtgSolucao.Columns[0].HeaderText = "Index";
                this.dtgSolucao.Columns[1].HeaderText = "Map";
                this.dtgSolucao.Columns[2].HeaderText = "Steps";
            }
            else
            {
                this.dtgSolucao.DataSource = null;
            }
        }

        #endregion
    }

}