package lessalopards.littlesister.DAO;

import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DatabaseConnection {
    
    private static DatabaseConnection instance;
    private Connection connection;
    private String url = "jdbc:sqlserver://littleister.database.windows.net:1433;";
    private String username = "TestUser";
    private String password = "Azerty12";

    private DatabaseConnection() throws SQLException {
        this.connection = DriverManager.getConnection(url, username, password);
    }

    public Connection getConnection() {
        return connection;
    }

    public static DatabaseConnection getInstance() throws SQLException {
        if (instance == null) {
            instance = new DatabaseConnection();
        } else if (instance.getConnection().isClosed()) {
            instance = new DatabaseConnection();
        }

        return instance;
    }
}
