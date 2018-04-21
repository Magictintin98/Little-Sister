package lessalopards.littlesister.Model;

public class Position {

    private int id;
    private String name;
    private int cameraId;

    public Position(int id, String name, int cameraId) {
        this.id = id;
        this.name = name;
        this.cameraId = cameraId;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getCameraId() {
        return cameraId;
    }

    public void setCameraId(int cameraId) {
        this.cameraId = cameraId;
    }
}
