# Nombre del Proyecto API

Esta API REST esta desarrollada con .NET 7, hace parte de un ejercicio de programacion bajo una arquitectura MVC y donde cuyo objetivo principal es ingresar un numero
entero en los rangos 0 y 999.999.999.999; donde su resultado debe darse como la lectura de dicho numero pero en idioma español.

## Características

Para este proyecto se contemplo los siguientes concepto:

- .NET 7
- C#
- XUnit
- Swagger y sus anotaciones
- Global Filter Exception
- Validaciones y atributos de validacion DTOs
- Flujo JWT (autenticacion y authorizacion por bearer token)
- Inyección de dependencias
- Changelog
- Docker


## Requisitos previos

- .NET 7 SDK
- IDE de su preferencia

## Instalación

1. Clona el repositorio:

    https://github.com/jehernandezcode/number-to-letters-net-7.git

2. Navega al directorio del proyecto:

3. Restaura las dependencias:

## Uso Local

1. Ejecutar el proyecto

dotnet run --project api-number-at-letters/api-number-at-letters.csproj

2. La Apí estara disponible en: https://localhost:7261

3. Accede a la documentacion de Swagger en: https://localhost:7261/swagger/index.html

4. Endpoints

- POST - /api/Authentication: Iniciar sessión y obtener token jwt (1 min de expiracion para efectos de prueba)

Las credeciales por defecto para un login correcto son: userName = 'userConverter' y password = '123456789'

curl --location 'https://localhost:7261/api/Authentication' \
--header 'Content-Type: application/json' \
--data '{
    "userName": "userConverter",
    "password": "123456789"
}'

- POST - /api/NumberConvert: Este servicio esta protegido por JWT el cual debe ser enviado en el Header Authorization = Bearer + token

curl --location 'https://localhost:7261/api/NumberConvert' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiJ1c2VyQ29udmVydGVyIiwibmJmIjoxNzE5OTI2NzE4LCJleHAiOjE3MTk5MjY3NzgsImlhdCI6MTcxOTkyNjcxOH0.ycSCT3NhUpThKPRkDHnKD0pOqnPzD-UJ-KiwbFB_FTE' \
--data '{
    "number": 3243245235
}'

# Uso de api Publica

- POST - /api/Authentication: Iniciar sessión y obtener token jwt (1 min de expiracion para efectos de prueba)

Las credeciales por defecto para un login correcto son: userName = 'userConverter' y password = '123456789'

curl --location 'http://54.198.206.104/api/Authentication' \
--header 'Content-Type: application/json' \
--data '{
    "userName": "userConverter",
    "password": "123456789"
}'


- POST - /api/NumberConvert: Este servicio esta protegido por JWT el cual debe ser enviado en el Header Authorization = Bearer + token

curl --location 'http://54.198.206.104/api/NumberConvert' \
--header 'Content-Type: application/json' \
--header 'Authorization: Bearer token' \
--data '{
    "number": 3243245235
}'

# Coleccion Postman

Este recurso se encuentra en la raiz del proyecto.

# Construir imagen de docker

Para usar el archivo dockerfile para construir un contenedor la api:

- Al nivel del dockerfile ejecutar

1. Construir la imagen segun los pasos en el dockerfile

    docker build -t api-number-at-letters .

2. Lanzar el contedor con la imagen de base

    docker run -d -p 80:80 api-number-at-letters

# Proceso de despliegue en AWS EC2

1. Crear instancia de ec2 de su preferencia

2. Conectarse a la instancia para interactuar por cli y ejecutar los siguientes numerales

3. Actualizar OS instancia
  
    sudo apt-get update

4. Instalar docker.io

    sudo apt install docker.io

5. Opcional - Agregar permisos sudo para el perfil actual

    sudo usermod -aG docker $USER

6. Reiniciamos la instancia

    sudo reboot

7. Clonamos la rama main del repositorio actual 

    https://github.com/jehernandezcode/number-to-letters-net-7.git

8. Seguimos los pasos del apartado anterior (Construir imagen de docker)

9. Asegurar las reglas de entrada de la instancia para el puerto 80 de http

10. Hacer uso de la api segun el apartado anterior (Uso de api Publica)

