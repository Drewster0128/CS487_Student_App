import java.util.ArrayList;
import java.sql.*;

public class Student
{
    private String aNumber;
    private String fName;
    private String lName;
    private String email;
    private String username;
    private String password;

    public static ArrayList<Student> getAllStudents()
    {
        ArrayList<Student> students = new ArrayList<Student>();
        try
        {
            Connection conn = Database.connect();
            ResultSet rs = conn.createStatement().executeQuery("SELECT * FROM student");
            while(rs.next())
            {
                students.add(new Student(rs.getString("aNumber"), rs.getString("fName"), rs.getString("lName"), rs.getString("email"), rs.getString("username"), rs.getString("password")));
            }
            conn.close();
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
        }
        return students;
    }

    public static boolean login(String username, String password)
    {
        try
        {
            Connection conn = Database.connect();
            ResultSet rs = conn.createStatement().executeQuery(String.format("SELECT * FROM student where username = '%s' and password = '%s'", username, password));
            if(rs.next())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch(SQLException e)
        {
            System.out.println(e.getMessage());
            return false;
        }
    }

    public Student()
    {

    }

    public Student(String aNumber, String fName, String lName, String email, String username, String password)
    {
        setANumber(aNumber);
        setFirstName(fName);
        setLastName(lName);
        setEmail(email);
        setUsername(username);
        setPassword(password);
    }

    public void setANumber(String aNumber)
    {
        if(aNumber.length() == 8)
        {
            for(int i = 0; i < aNumber.length(); i++)
            {
                if(!Character.isDigit(aNumber.charAt(i)))
                {
                    throw new IllegalArgumentException("A numbers must only contain digits");
                }
            }
            this.aNumber = aNumber;
        }
        else
        {
            throw new IllegalArgumentException("A numbers must contain 8 digits");
        }
    }

    public String getANumber()
    {
        return this.aNumber;
    }

    public void setFirstName(String fName)
    {
        this.fName = fName;
    }

    public String getFirstName()
    {
        return this.fName;
    }

    public void setLastName(String lName)
    {
        this.lName = lName;
    }

    public String getLastName()
    {
        return this.lName;
    }

    public void setEmail(String email)
    {
        if(email.endsWith("@hawk.iit.edu"))
        {
            this.email = email;
        }
        else
        {
            throw new IllegalArgumentException("Email must end in hawk.iit.edu");
        }
    }

    public String getEmail()
    {
        return this.email;
    }

    public void setUsername(String username)
    {
        this.username = username;
    }

    public String getUsername()
    {
        return this.username;
    }

    public void setPassword(String password)
    {
        this.password = password;
    }

    public String getPassword()
    {
        return this.password;
    }
}