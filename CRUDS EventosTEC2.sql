USE [EventosTEC]
GO

----------------------CRUDS EventType---------------------------------------
-- Crear el tipo de evento "Académico"
INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Académico', 'académico');

-- Crear el tipo de evento "Recreativo"
INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Recreativo', 'recreativo');

INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Música', 'música');

-- Leer (Read)
SELECT * FROM [dbo].[EventType];

--Actualizar (Update)
UPDATE [dbo].[EventType]
SET [name] = 'Seminario', [description] = 'Eventos de tipo seminario'
WHERE [idEventType] = 1;

--Eliminar (Delete)
DELETE FROM [dbo].[EventType]
WHERE [idEventType] = 1;

---------------------CRUDS EventState---------------------------------------
-- Insertar el estado "No iniciado"
INSERT INTO [dbo].[EventState] ([name])
VALUES ('No iniciado');

-- Insertar el estado "En progreso"
INSERT INTO [dbo].[EventState] ([name])
VALUES ('En progreso');

-- Insertar el estado "Terminado"
INSERT INTO [dbo].[EventState] ([name])
VALUES ('Terminado');

-- CapacityTYPE
INSERT INTO [dbo].[CapacityType] ([name])
VALUES ('Ilimitado');

INSERT INTO [dbo].[CapacityType] ([name])
VALUES ('Cupo límitado');

INSERT INTO [dbo].[CapacityType] ([name])
VALUES ('Reservado');
---------------------CRUDS Event-----------------------------------------
/*
1, B3-06
2, Centro de las Artes
3, Piscina TEC
4, Cancha Multiusos
5, Auditorio de Computación
*/


INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Música', 'música');

-- Evento 1
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType], idCapacityType, [idFacility])
VALUES ('Conferencia de Tecnología', '2023-10-20 03:00:00 PM', 1, 'Una conferencia sobre las últimas tecnologías', 'TechCon', '200', '25', 1,2, 1);

-- Evento 2
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType], idCapacityType, [idFacility])
VALUES ('Feria de Libros', '2023-10-20 01:00:00 PM', 2, 'Una feria para amantes de la lectura', 'Book Expo', '300', '0', 1,1 , 2);

-- Evento 3
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType], idCapacityType, [idFacility])
VALUES ('Concierto en Vivo', '2023-10-20 05:00:00 PM', 3, 'Un concierto de tu banda favorita', 'Live Music Co.', '150', '50', 3,1, 2);

-- Evento 4
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType], idCapacityType,[idFacility])
VALUES ('Seminario de Marketing', '20231020 03:00:00 PM', 1, 'Aprende estrategias de marketing efectivas', 'Marketing Pro', '150', '30', 1,2, 5);

-- Evento 4
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType],idCapacityType,[idFacility])
VALUES ('Partidos de baloncesto', '20231020 01:00:00 PM', 1, 'Prueba bases de datos con tiempo', 'Raul', '150', '30', 2, 2, 4);

-- Evento 4
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType], idCapacityType,[idFacility])
VALUES ('Seminario de Marketing', '20231120 03:00:00 PM', 1, 'Aprende estrategias de marketing efectivas', 'Marketing Pro', '150', '30', 1,2, 5);

-- Evento 4
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [capacityNumber], [entryCost], [idEventType],idCapacityType,[idFacility])
VALUES ('Partidos de baloncesto', '20231205 01:00:00 PM', 1, 'Prueba bases de datos con tiempo', 'Raul', '150', '30', 2, 2, 4);

UPDATE dbo.[Event] SET idImage=1;



SELECT * FROM EventType;
SELECT * FROM dbo.[Event];

--DELETE FROM dbo.[Event];
---------------------CRUDS FacilityType-----------------------------------------
--instalacion 1
INSERT INTO FacilityType (name)
VALUES ('Audla');
--instalacion 2
INSERT INTO FacilityType (name)
VALUES ('Laboratorio');
--instalacion 3
INSERT INTO FacilityType (name)
VALUES ('auditorio');
--instalacion 4
INSERT INTO FacilityType (name)
VALUES ('parqueo');

SELECT * FROM FacilityType;

SELECT * FROM FacilityType WHERE idFacilityType = 1;

UPDATE FacilityType SET name = 'Nuevo nombre' WHERE idFacilityType = 1;

DELETE FROM FacilityType WHERE idFacilityType = 1;

---------------------CRUDS Location-----------------------------------------
-- Insertar el departamento de Informática
INSERT INTO Location (description, coordinates, inCampus)
VALUES ('Departamento de Informática', geography::STPointFromText('POINT(9.856827 -83.915698)', 4326), 1);

-- Insertar el departamento de Electrónica
INSERT INTO Location (description, coordinates, inCampus)
VALUES ('Departamento de Electrónica', geography::STPointFromText('POINT(9.857236 -83.916754)', 4326), 1);

-- Insertar el departamento de Mecánica
INSERT INTO Location (description, coordinates, inCampus)
VALUES ('Departamento de Mecánica', geography::STPointFromText('POINT(9.857640 -83.915418)', 4326), 1);

-- Insertar el departamento de Matemáticas
INSERT INTO Location (description, coordinates, inCampus)
VALUES ('Departamento de Matemáticas', geography::STPointFromText('POINT(9.855763 -83.917143)', 4326), 1);

-- Insertar el departamento de Arquitectura
INSERT INTO Location (description, coordinates, inCampus)
VALUES ('Departamento de Arquitectura', geography::STPointFromText('POINT(9.854951 -83.918194)', 4326), 1);

SELECT * FROM Location;

UPDATE Location SET description = 'Nueva descripción' WHERE idLocation = 1;

DELETE FROM Location WHERE idLocation = 1;

---------------------CRUDS Constraint-----------------------------------------
-- Restricción: No se permiten animales en las instalaciones
INSERT INTO [dbo].[Constraint] (name, description)
VALUES ('No se permiten animales', 'Por razones de seguridad e higiene.');

-- Restricción: Prohibido traer comida de fuera
INSERT INTO [dbo].[Constraint] (name, description)
VALUES ('Prohibido traer comida de fuera', 'Con el fin de mantener la limpieza.');

-- Restricción: Uso de equipo de protección obligatorio
INSERT INTO [dbo].[Constraint] (name, description)
VALUES ('Uso de equipo de protección obligatorio', 'Para garantizar la seguridad de todos.');

-- Restricción: Horario de acceso restringido
INSERT INTO [dbo].[Constraint] (name, description)
VALUES ('Horario de acceso restringido', 'El acceso a ciertas áreas está restringido.');

-- Restricción: No se permite fumar en las instalaciones
INSERT INTO [dbo].[Constraint] (name, description)
VALUES ('No se permite fumar', 'Por razones de salud y seguridad.');

-- Leer todos los registros de restricciones
SELECT * FROM[dbo].[Constraint];

-- Actualizar una restricción existente
UPDATE [dbo].[Constraint]
SET name = 'Nueva Restricción', description = 'Nueva descripción de la restricción'
WHERE idConstraint = 1;

-- Eliminar una restricción
DELETE FROM [dbo].[Constraint] WHERE idConstraint = 1;



---------------------CRUDS FacilityAdministrator-----------------------------------------
-- Insertar un nuevo administrador de instalaciones
INSERT INTO FacilityAdministrator (email)
VALUES ('raulsanabria@estudiantec.cr');

-- Leer todos los administradores de instalaciones
SELECT * FROM FacilityAdministrator;

-- Actualizar el correo electrónico de un administrador existente
UPDATE FacilityAdministrator
SET email = 'nuevo_correo@admin.com'
WHERE idFacilityAdministrator = 1;

-- Eliminar un administrador de instalaciones
DELETE FROM FacilityAdministrator WHERE idFacilityAdministrator = 1;

---------------------CRUDS Persona-----------------------------------------
-- Insertar una nueva persona
INSERT INTO Person (email, personPassword, cardNumber, personName, firstLastName, secondLastName, debt)
VALUES ('raulsanabria@estudiantec.cr', '1234', 12345, 'Raul', 'Sanabria', 'Marroquin', 0);

-- Leer todos los registros de personas
SELECT * FROM Person;

-- Actualizar los datos de una persona existente
UPDATE Person
SET personPassword = 'nueva_clave', debt = 100
WHERE email = 'correo@ejemplo.com';

-- Eliminar una persona
DELETE FROM Person WHERE email = 'correo@ejemplo.com';

---------------------CRUDS Facility-----------------------------------------
-- Establecimiento: Biblioteca
INSERT INTO Facility (idFacility, name, idBuildingType, capacity, idLocation, idFacilityAdministrator)
VALUES (1, 'Biblioteca Central', 1, 500, 1, 2);

-- Establecimiento: Laboratorio de Informática
INSERT INTO Facility (idFacility, name, idBuildingType, capacity, idLocation, idFacilityAdministrator)
VALUES (2, 'Laboratorio de Informática', 2, 30, 2, 2);

-- Establecimiento: Auditorio
INSERT INTO Facility (idFacility, name, idBuildingType, capacity, idLocation, idFacilityAdministrator)
VALUES (3, 'Auditorio Principal', 3, 200, 1, 2);

-- Establecimiento: Cafetería
INSERT INTO Facility (idFacility, name, idBuildingType, capacity, idLocation, idFacilityAdministrator)
VALUES (4, 'Cafetería Universitaria', 4, 100, 3, 2);

-- Establecimiento: Gimnasio
INSERT INTO Facility (idFacility, name, idBuildingType, capacity, idLocation, idFacilityAdministrator)
VALUES (5, 'Gimnasio Deportivo', 3, 150, 2, 2);


-- Leer todos los registros de establecimientos
SELECT * FROM Facility;

-- Actualizar los datos de un establecimiento existente
UPDATE Facility
SET name = 'Nuevo Nombre del Establecimiento', capacity = 150
WHERE idFacility = 1;

-- Eliminar un establecimiento
DELETE FROM Facility WHERE idFacility = 1;


-- Descripción: Crea un nuevo evento en la base de datos.
-----------------------------------------------------------
CREATE PROCEDURE [dbo].[CreateEvent]
    @name NVARCHAR(50),
    @date DATETIME,
    @idEventState INT,
    @description NVARCHAR(50),
    @organizer NVARCHAR(50),
    @maxCapacity NCHAR(10),
    @entryCost NCHAR(10),
    @idEventType INT
AS
BEGIN
    SET NOCOUNT ON -- No retorne metadatos

    DECLARE @ErrorNumber INT, @ErrorSeverity INT, @ErrorState INT, @CustomError INT
    DECLARE @Message VARCHAR(200)
    DECLARE @InicieTransaccion BIT

    DECLARE @idEvent INT

    -- Validación de los parámetros
    IF @name IS NOT NULL AND @date IS NOT NULL AND @idEventState IS NOT NULL
    BEGIN
        SET @InicieTransaccion = 0

        -- El bit cambia a uno únicamente si es la primera transacción en la cola
        IF @@TRANCOUNT = 0
        BEGIN
            SET @InicieTransaccion = 1
            SET TRANSACTION ISOLATION LEVEL READ COMMITTED
            BEGIN TRANSACTION
        END

        BEGIN TRY
            SET @CustomError = 2001

            -- Inserta un nuevo evento
            INSERT INTO dbo.Event (
                [name], [date], [idEventState], [description], [organizer], [maxCapacity], [entryCost], [idEventType]
            )
            VALUES (
                @name, @date, @idEventState, @description, @organizer, @maxCapacity, @entryCost, @idEventType
            );

            SET @idEvent = SCOPE_IDENTITY();


            -- Si se inicia la transacción, se hace commit
            IF @InicieTransaccion = 1
            BEGIN
                COMMIT
            END
        END TRY
        BEGIN CATCH
            SET @ErrorNumber = ERROR_NUMBER()
            SET @ErrorSeverity = ERROR_SEVERITY()
            SET @ErrorState = ERROR_STATE()
            SET @Message = ERROR_MESSAGE()

            IF @InicieTransaccion = 1
            BEGIN
                ROLLBACK
            END

            RAISEERROR('%s - Error Number: %i', @ErrorSeverity, @ErrorState, @Message, @CustomError)
        END CATCH
    END
END
