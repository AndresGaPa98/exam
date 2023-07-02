# exam
Prueba técnica SoloTalento

#Como ejecutar el proyecto de angular

En la ruta donde se encuentran los diversos proyectos de net core se deberá abir el proyecto WebApplication > FrontEnd > WebApplication, una vez abierta esta carpeta usted se encuentra en el proyecto de angular, para que el proyecto funcione deberá instalar los node_modules con el comando npm i.
Una vez que se hayan descargado los paquetes ya podrá ejecutar el programa con el comando npm start.
No olvide validar que el puerto marcado en los archivos environment corresponda a su puerto del backend.

#Como ejecutar el proyecto de net core

En la ruta donde se encuentrar los diversos proyectos de net core deberá abir la solución de los proyectos para que se abra visual studio.
Una vez que el IDE este abierto lo primero que deberá hacer es Restaurar los paquetes Nuget y abrir la consola del administrador de paquetes, una vez que la consola del administrador de paquetes este abierta deberá seleccionar el proyecto
"WebApplication.Data" y deberá generar la migracion inicial con el comando add-migration Initial y posterior a esto ejecutar el comando update-database.
En caso de error en estos ultimos pasos verifique que la cadena de conexión corresponda a su instancia de su base de datos.

Una vez realizado estos pasos deberá poder visualizar la aplicación web funcional.