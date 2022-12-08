using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConexaoBd
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-AL96SA4E\SQLEXPRESS;integrated security=SSPI;initial Catalog=db_hotel");
            con.Open();

            /* string strUp = "update tbl_Cliente set nm_cli = 'Fabio Algusto'where cd_cli = 1";
             SqlCommand cmdUp = new SqlCommand(strUp, con);
             cmdUp.ExecuteNonQuery();*/

            /*string strDel = "Delete from tbl_Cliente where cd_cli = 7";
            SqlCommand cmdDel = new SqlCommand(strDel, con);
            cmdDel.ExecuteNonQuery();*/

            Console.WriteLine("Informe o nome do cliente: ");
            string VNome = Console.ReadLine();

            Console.WriteLine("Informe o sexo do cliente: ");
            string VSexo = Console.ReadLine();

            Console.WriteLine("Informe o CPF do cliente: ");
            string VCpf = Console.ReadLine();

            Console.WriteLine("Informe a cidade do cliente: ");
            string VCidade = Console.ReadLine();

            string strIns = string.Format("insert into tbl_cliente(nm_cli, sg_sexo, no_cpf, nm_cidade)values('{0}','{1}','{2}','{3}')",VNome,VSexo,VCpf,VCidade);
            SqlCommand cmdIns = new SqlCommand(strIns, con);
            cmdIns.ExecuteNonQuery();

            string strConsulta = "select * from tbl_cliente";
            SqlCommand cmd = new SqlCommand(strConsulta, con);
            SqlDataReader dados = cmd.ExecuteReader();

            while (dados.Read()) 
            {
                Console.WriteLine("Código:{0},Nome:{1},Sexo:{2},CPF:{3},Cidade:{4}", dados["cd_cli"], dados["nm_cli"], dados["sg_sexo"], dados["no_cpf"], dados["nm_cidade"]);
            }
        }
    }
}
