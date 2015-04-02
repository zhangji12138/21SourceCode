using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OnLineExam.DataBaseClass;
using OnLineExam.BusinessClass;
using System.Data.SqlClient;
public partial class Web_PaperDetail : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
       {          
               string loginName = Session["userID"].ToString();
               Usersmr user = new Usersmr();
               user.LoadData(loginName);
               labUser.Text = user.UserName;
               InitData();        
          
        }
    }
    //初始化试卷，从数据库中将试题取出
    protected void InitData()
    {       
        DataBase DB = new DataBase();
        int paperID = Convert.ToInt32(Request.QueryString["PaperID"].ToString());


        SqlParameter[] Params1 = new SqlParameter[2];     
        Params1[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params1[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "单选题");            //题目类型        
        DataSet ds1 = DB.GetDataSet("Proc_PaperDetailmr", Params1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();

        SqlParameter[] Params2 = new SqlParameter[2];
        Params2[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params2[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "多选题");            //题目类型        
        DataSet ds2 = DB.GetDataSet("Proc_PaperDetailmr", Params2);
        GridView2.DataSource = ds2;
        GridView2.DataBind();

        SqlParameter[] Params3 = new SqlParameter[2];
        Params3[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params3[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "判断题");            //题目类型        
        DataSet ds3 = DB.GetDataSet("Proc_PaperDetailmr", Params3);
        GridView3.DataSource = ds3;
        GridView3.DataBind();

        SqlParameter[] Params4 = new SqlParameter[2];
        Params4[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params4[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "填空题");            //题目类型        
        DataSet ds4 = DB.GetDataSet("Proc_PaperDetailmr", Params4);
        GridView4.DataSource = ds4;
        GridView4.DataBind();

        SqlParameter[] Params5 = new SqlParameter[2];
        Params5[0] = DB.MakeInParam("@PaperID", SqlDbType.Int, 4, paperID);               //试卷编号
        Params5[1] = DB.MakeInParam("@Type", SqlDbType.VarChar, 10, "问答题");            //题目类型        
        DataSet ds5 = DB.GetDataSet("Proc_PaperDetailmr", Params5);
        GridView5.DataSource = ds5;
        GridView5.DataBind();
        
    }
    protected void imgBtnReturn_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("PaperLists.aspx");
    }
}
