# Notice Api

> Web API for managing notices in the "Korepetitio" tutoring app.

## About the project

Notice API is a core microservice of the **Korepetitio** platform (planned release: late 2026). It handles the full lifecycle of tutoring advertisements.

**Key highlights:**
* **CRUD & Beyond:** Endpoints for adding, renewing, and editing notices.
* **Data Integrity:** Implemented **Soft Delete** pattern to preserve historical data.
* **Event-Driven:** Integration with **RabbitMQ** for seamless cross-service communication.
## Tech Stack

* **Backend:** .NET 9.0 (C#)
* **Database:** PostgreSQL
* **Infrastructure:** RabbitMQ / Keycloak
* **Documentation:** Swagger

## Installation and deploy

1. Clone repository
   ```bash
   git clone https://github.com/JHebel1/notice-api-korepetio.git
   ```
3. Ensure you have Docker installed
4. Run this command in cmd:
   ```bash
   docker compose -f docker-compose.yml up --build
   ```
5. Test endpoints using:
   ```bash
   http://localhost:7100/swagger/index.html
   ```

## License 

Distributed under the MIT License

## Contact

Email: jakubhebelll@gmail.com
   
