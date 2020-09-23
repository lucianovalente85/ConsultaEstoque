using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Dominio.DAO
{
    public class ProdutoDAO : BaseDAO<Produto>, IDAO<Produto>
    {
        protected override void AdicionarParametrosExcetoId(SqlCommand cmd, Produto obj)
        {
            cmd.Parameters.AddWithValue("@CODIGO", obj.Codigo);
            cmd.Parameters.AddWithValue("@DESCRICAO", obj.Descricao);
            cmd.Parameters.AddWithValue("@ESTOQUE", obj.Estoque);
        }

        protected override Produto GetObjeto(DataRow reg)
        {
            var obj = new Produto();

            obj.Id = reg["ID"].ToString();
            obj.Codigo = Convert.ToInt32(reg["CODIGO"]);
            obj.Descricao = reg["DESCRICAO"].ToString();
            obj.Estoque = Convert.ToDouble(reg["ESTOQUE"]);

            return obj;
        }

        protected override string GetSqlDelete() => "DELETE FROM PRODUTO WHERE ID=@ID";

        protected override string GetSqlInsert() => "INSERT INTO PRODUTO (ID, CODIGO, DESCRICAO, ESTOQUE) VALUES (@ID, @CODIGO, @DESCRICAO, @ESTOQUE)";

        protected override string GetSqlSelect() => "SELECT * FROM PRODUTO ORDER BY CODIGO";

        protected override string GetSqlSelectId() => "SELECT * FROM PRODUTO WHERE ID=@ID";

        protected override string GetSqlUpdate() => "UPDATE PRODUTO SET CODIGO=@CODIGO, DESCRICAO=@DESCRICAO, ESTOQUE=@ESTOQUE WHERE ID=@ID";
    }
}
