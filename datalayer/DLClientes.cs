using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ModelLayer;


namespace DataLayer
{
    public class DLClientes
    {

        #region Conexão

        public string strConnection = ConfigurationManager.ConnectionStrings["ConCRUDBasico"].ConnectionString;

        #endregion

        #region Comando

        public const string strDelete = "DELETE FROM Clientes WHERE IdCliente = @IdCliente";
        public const string strInsert = "INSERT INTO Clientes Values (@Nome, @Endereco, @Telefone, @Sexo, @Ativo, @DataCadastro) SELECT SCOPE_IDENTITY()";
        public const string strUpdate = "UPDATE Clientes SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, Sexo = @Sexo, Ativo = @Ativo, DataCadastro = @DataCadastro WHERE IdCliente = @IdCliente ";
        public const string strSelect = "SELECT IdCliente, Nome, Endereco, Telefone, Sexo, Ativo, DataCadastro FROM Clientes";
        public const string strSelectNome = "SELECT IdCliente, Nome, Endereco, Telefone, Sexo, Ativo, DataCadastro FROM Clientes WHERE (@Nome IS NULL OR Nome Like '%' + @Nome + '%)";


        #endregion

        #region Métodos

        public int Excluir(int IdCliente) 
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection)) 
            {
                using (SqlCommand objComando = new SqlCommand(strDelete, objConexao)) 
                {
                    objComando.Parameters.AddWithValue("@IdCliente", IdCliente);
                    
                    objConexao.Open();

                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Gravar(MLClientes objMLClientes)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strInsert, objConexao))
                {
                    objComando.Parameters.AddWithValue("@Nome", objMLClientes.Nome);
                    objComando.Parameters.AddWithValue("@Endereco", objMLClientes.Endereco);
                    objComando.Parameters.AddWithValue("@Telefone", objMLClientes.Telefone);
                    objComando.Parameters.AddWithValue("@Sexo", objMLClientes.Sexo);
                    objComando.Parameters.AddWithValue("@Ativo", objMLClientes.Ativo);
                    objComando.Parameters.AddWithValue("@DataCadastro", objMLClientes.DataCadastro);

                    objConexao.Open();
                    //Utilizo o ExecuteScalar para obter o ID Gravado.
                    retorno = Convert.ToInt32(objComando.ExecuteScalar());

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public int Atualizar(MLClientes objMLClientes)
        {
            int retorno = 0;

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strUpdate, objConexao))
                {
                    objComando.Parameters.AddWithValue("@IdCliente", objMLClientes.IdCliente);
                    objComando.Parameters.AddWithValue("@Nome", objMLClientes.Nome);
                    objComando.Parameters.AddWithValue("@Endereco", objMLClientes.Endereco);
                    objComando.Parameters.AddWithValue("@Telefone", objMLClientes.Telefone);
                    objComando.Parameters.AddWithValue("@Sexo", objMLClientes.Sexo);
                    objComando.Parameters.AddWithValue("@Ativo", objMLClientes.Ativo);
                    objComando.Parameters.AddWithValue("@DataCadastro", objMLClientes.DataCadastro);

                    objConexao.Open();
                    
                    retorno = objComando.ExecuteNonQuery();

                    objConexao.Close();
                }
            }

            return retorno;
        }

        public List<MLClientes> Consultar()
        {
            List<MLClientes> lstMLClientes = new List<MLClientes>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelect, objConexao))
                {
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows) 
                    {

                        while (objDataReader.Read())
                        {
                            MLClientes objMLCliente = new MLClientes();

                            objMLCliente.IdCliente = Convert.ToInt32(objDataReader["IdCliente"].ToString());
                            objMLCliente.Nome = objDataReader["Nome"].ToString();
                            objMLCliente.Endereco = objDataReader["Endereco"].ToString();
                            objMLCliente.Telefone = objDataReader["Telefone"].ToString();
                            objMLCliente.Sexo = objDataReader["Sexo"].ToString();

                            if (objDataReader["Ativo"].ToString().Equals("0"))
                            {
                                objMLCliente.Ativo = false;
                            }
                            else
                            {
                                objMLCliente.Ativo = true;
                            }

                            objMLCliente.DataCadastro = Convert.ToDateTime(objDataReader["DataCadastro"].ToString());

                            lstMLClientes.Add(objMLCliente);
                        }
                        
                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }

            return lstMLClientes;
        }

        public List<MLClientes> ConsultarNome(MLClientes objMLClientes)
        {
            List<MLClientes> lstMLClientes = new List<MLClientes>();

            using (SqlConnection objConexao = new SqlConnection(strConnection))
            {
                using (SqlCommand objComando = new SqlCommand(strSelectNome, objConexao))
                {
                    if (String.IsNullOrEmpty(objMLClientes.Nome))
                    {
                        objComando.Parameters.AddWithValue("@Nome", DBNull.Value);
                    }
                    else
                    {
                        objComando.Parameters.AddWithValue("@Nome", objMLClientes.Nome);
                    }
                    
                    objConexao.Open();

                    SqlDataReader objDataReader = objComando.ExecuteReader();

                    if (objDataReader.HasRows)
                    {

                        while (objDataReader.Read())
                        {
                            MLClientes objMLCliente = new MLClientes();

                            objMLCliente.IdCliente = Convert.ToInt32(objDataReader["IdCliente"].ToString());
                            objMLCliente.Nome = objDataReader["Nome"].ToString();
                            objMLCliente.Endereco = objDataReader["Endereco"].ToString();
                            objMLCliente.Telefone = objDataReader["Telefone"].ToString();
                            objMLCliente.Sexo = objDataReader["Sexo"].ToString();

                            if (objDataReader["Ativo"].ToString().Equals("0"))
                            {
                                objMLCliente.Ativo = false;
                            }
                            else
                            {
                                objMLCliente.Ativo = true;
                            }

                            objMLCliente.DataCadastro = Convert.ToDateTime(objDataReader["DataCadastro"].ToString());

                            lstMLClientes.Add(objMLCliente);
                        }

                        objDataReader.Close();
                    }

                    objConexao.Close();
                }
            }

            return lstMLClientes;
        }
        

        #endregion

    }
}
