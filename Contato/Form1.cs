using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Contato
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnectionStringBuilder conexaoBanco()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "contato";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            conexaoBD.SslMode = 0;
            return conexaoBD;
        }

        private void atualizarGrid()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "SELECT * FROM pessoa";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgContato.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dgContato.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                    row.Cells[0].Value = reader.GetInt32(0);//ID
                    row.Cells[1].Value = reader.GetString(1);//NOME
                    row.Cells[2].Value = reader.GetString(2);//TELEFONE
                    row.Cells[3].Value = reader.GetString(3);//REDESOCIAL
                    row.Cells[4].Value = reader.GetString(4);//ATIVO
                    dgContato.Rows.Add(row);//ADICIONO A LINHA NA TABELA
                }

                realizaConexacoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void limparCampos()
        {
            tbID.Clear();
            tbNome.Clear();
            tbTelefone.Clear();
            tbRedeSocial.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO pessoa (nomePessoa,telefonePessoa,redeSocialPessoa) " +
                    "VALUES('" + tbNome.Text + "', '" + tbTelefone.Text + "','" + tbRedeSocial.Text + "')";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();
                MessageBox.Show("Parabéns\nInserido com sucesso");
                atualizarGrid();
                limparCampos();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dgContato_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgContato.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgContato.CurrentRow.Selected = true;
                //preenche os textbox com as células da linha selecionada
                tbNome.Text = dgContato.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                tbTelefone.Text = dgContato.Rows[e.RowIndex].Cells["ColumnTelefone"].FormattedValue.ToString();
                tbRedeSocial.Text = dgContato.Rows[e.RowIndex].Cells["ColumnRedeSocial"].FormattedValue.ToString();
                tbID.Text = dgContato.Rows[e.RowIndex].Cells["ColumnID"].FormattedValue.ToString();
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                comandoMySql.CommandText = "UPDATE pessoa SET nomePessoa= '" + tbNome.Text + "', " +
                    "telefonePessoa = '" + tbTelefone.Text + "', " +
                    "redeSocialPessoa = '" + tbRedeSocial.Text + "' " +
                    " WHERE idPessoa = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Sucesso\nAtualizado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private void btDeletar_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open(); //Abre a conexão com o banco

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand(); //Crio um comando SQL
                // "DELETE FROM filme WHERE idFilme = "+ textBoxId.Text +""
                comandoMySql.CommandText = "UPDATE pessoa SET ativoPessoa = 0 WHERE idPessoa = " + tbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close(); // Fecho a conexão com o banco
                MessageBox.Show("Uhlll!\nDeletado com sucesso"); //Exibo mensagem de aviso
                atualizarGrid();
                limparCampos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Não foi possivel abrir a conexão! ");
                Console.WriteLine(ex.Message);
            }
        }

        private int verificaSeExiste()
        {
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                comandoMySql.CommandText = "SELECT * FROM pessoa WHERE idPessoa = " + Convert.ToInt32(tbPesquisarID.Text);
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgContato.Rows.Clear();

                while (reader.Read())
                {
                    realizaConexacoBD.Close();
                    return 1;

                }

                realizaConexacoBD.Close();
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            int aux = verificaSeExiste();
            MySqlConnectionStringBuilder conexaoBD = conexaoBanco();
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());
            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                comandoMySql.CommandText = "SELECT * FROM pessoa WHERE idPessoa = " + Convert.ToInt32(tbPesquisarID.Text);
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dgContato.Rows.Clear();
                if (aux == 1)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)dgContato.Rows[0].Clone();//FAZ UM CAST E CLONA A LINHA DA TABELA
                        row.Cells[0].Value = reader.GetInt32(0);//ID
                        row.Cells[1].Value = reader.GetString(1);//NOME
                        row.Cells[2].Value = reader.GetString(2);//TELEFONE
                        row.Cells[3].Value = reader.GetString(3);//REDESOCIAL
                        row.Cells[4].Value = reader.GetString(4);//ATIVO
                        dgContato.Rows.Add(row);//ADICIONO A LINHA NA TABELA
                        MessageBox.Show("Id encontrado");
                    }
                }
                else {
                    MessageBox.Show("Id não encontrado");
                }

                
                realizaConexacoBD.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
