import java.sql.*;

public class Database 
{
    private static final String URL = "jdbc:mysql://localhost:3306/student";
    private static final String USER = "root";
    private static final String PASS = "Bball#0128";

    public static Connection connect() throws SQLException
    {
       return DriverManager.getConnection(URL, USER, PASS);
    }
}
