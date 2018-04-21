package lessalopards.littlesister.DAO;

import android.util.Log;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.Date;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import lessalopards.littlesister.Model.User;

public class UserDAO {
    private String api = "http://littlesister2.azurewebsites.net/api/user";

    public ArrayList<User> getAllUsers() {
        StringBuilder sb = new StringBuilder();
        String stringJSON;
        String line;
        try {
            URL url = new URL(api + "/getall");
            URLConnection connection = url.openConnection();
            BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            while((line = br.readLine()) != null) {
                sb.append(line);
            }
            br.close();
        } catch (Exception e) {
            Log.d("update", e.getMessage());
        }
        stringJSON = sb.toString();
        return jsonToUsers(stringJSON);
    }

    public User getUser(int id) {
        StringBuilder sb = new StringBuilder();
        String stringJSON;
        String line;
        try {
            URL url = new URL(api + "/getbyid/" + id);
            URLConnection connection = url.openConnection();
            BufferedReader br = new BufferedReader(new InputStreamReader(connection.getInputStream()));
            while((line = br.readLine()) != null) {
                sb.append(line);
            }
            br.close();
        } catch (Exception e) {
            System.err.println(e.getMessage());
        }
        stringJSON = sb.toString();
        if(stringJSON==null) {
            ;
        }
        return jsonToUser(stringJSON);
    }

    public int createUser(String id, String name, String email, boolean ghostmode, int lastPosition, Date lastPositionTime, String appToken) {
        int responseCode = -1;

        try {
            URL url = new URL(api + "/create/");
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("POST");
            connection.setDoOutput(true);
            connection.setRequestProperty("Content-Type", "application/json");

            //Send credentials
            String query = newUserToJSON(id, name, email, ghostmode, lastPosition, lastPositionTime, appToken);

            OutputStream os = connection.getOutputStream();
            OutputStreamWriter osw = new OutputStreamWriter(os);
            osw.write(query);
            osw.flush();
            osw.close();
            os.close();
            responseCode = connection.getResponseCode();
            connection.disconnect();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return responseCode;
    }

    public int updateUser(String id, String name, String email, boolean ghostmode, int lastPosition, Date lastPositionTime, String appToken) {
        int responseCode = -1;
        try {
            URL url = new URL(api + "/update/" + id);
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod("PUT");
            connection.setDoOutput(true);
            connection.setRequestProperty("Content-Type", "application/json");

            //Send credentials
            String query = newUserToJSON(id, name, email, ghostmode, lastPosition, lastPositionTime, appToken);

            OutputStream os = connection.getOutputStream();
            OutputStreamWriter osw = new OutputStreamWriter(os);
            osw.write(query);
            osw.flush();
            osw.close();
            os.close();
            responseCode = connection.getResponseCode();
            connection.disconnect();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return responseCode;
    }

    private String newUserToJSON(String id, String name, String email, boolean ghostmode, int lastPosition, Date lastPositionTime, String appToken) {
        Gson gson = new Gson();
        User user = new User(id, name, email, ghostmode, lastPosition, lastPositionTime, appToken);
        return gson.toJson(user);
    }

    private User jsonToUser(String stringJSON) {
        User user;
        Gson gson = new Gson();
        Type UserType = new TypeToken<User>(){}.getType();
        user = gson.fromJson(stringJSON, UserType);
        return user;
    }

    private ArrayList<User> jsonToUsers(String stringJSON) {
        ArrayList<User> Users;
        Gson gson = new Gson();
        Type arrayListType = new TypeToken<ArrayList<User>>(){}.getType();
        Users = gson.fromJson(stringJSON, arrayListType);
        return Users;
    }
}
