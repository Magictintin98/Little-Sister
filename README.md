# Little Sister

Little Sister is an open-source project developed during the 2018 edition of the **TechOffice Hackathon** from the *Microsoft Innovation Center* in Mons. 

### Project members

[Nathan Pire](https://github.com/thelittlewozniak)
[Massimo Gentile](https://github.com/MassimoGentile)
[Simon Gauthier](https://github.com/GausiVagos)
[Xavier Vercruysse](https://github.com/xvercruysse)

## Description

Little Sister is an app whose aim is to minimise the time spent searching someone in a large company.
Every 5 minutes, a frame from each of the connected cameras will be captured and analysed using *Microsoft*'s **Face API** and **Computer Vision API**.
Each user identified by **Face API** will then be updated with the new position.
When an user asks for the location of another user, this other user will be sent a notification asking for his consent. If he approves, an immediate scan will be made, and his position will be returned to the asking user.
If he refuses, the first user will be informed and he will not be able to see the position of the other user.

### UML diagram
![ScreenShot](uml_diagram.jpg)
```mermaid
sequenceDiagram
Mobile/web app ->> API: Send request to locate user B
API ->> Mobile/web app: Ask consent from user B
Mobile/web app -->>API: Response from user B
API ->> Computer Vision: Sends a frame of each camera
Computer Vision -->> API: Return frames containing people
API ->> Face API : Sends frames containing people
Face API ->> Face API : Identifies people
Face API ->> API : Returns Camera's ids with identified people's ids
API ->> API : Update DB with new positions
API--x Mobile/web app: Return user B's position
Note right of Mobile/web app: If user B can't be located, his last known position will be sent
```


# License

See [Licence](https://github.com/xvercruysse/Little-Sister)
