using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Serialization;
class Banco
{

    public string mensagem = "Olá Banco";

    private List<Pessoa> lista=new List<Pessoa>();

    public void carregarBanco()
    {
        try
        {

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                "User ID=sa;Password=576171;" +
                "Server=localhost\\SQLEXPRESS;" +
                "Database=projetoclientes;" +
                "Trusted_Connection=False;"

            );

            using (SqlConnection conexao = new SqlConnection(builder.ConnectionString))
            {


                String sql = " Select * from clientes";

                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    conexao.Open();

                    using (SqlDataReader tabela = comando.ExecuteReader())
                    {

                        while (tabela.Read())
                        {
                           // System.Console.WriteLine(tabela["nome"]);
                           //Pessoa p1 = new Pessoa() { id = 1, nome = "Ana" };
                           lista.Add(
                                new Pessoa(){
                                    id = Convert.ToInt32(tabela["id"]),
                                    nome = tabela["nome"].ToString()
                                }
                           );
                        }

                    }
                }
            }

        }
        catch (Exception e)
        {
            System.Console.WriteLine("Error" + e.ToString);
        }
    }

    public List<Pessoa> GetLista()
    {
        return lista;
    }
}