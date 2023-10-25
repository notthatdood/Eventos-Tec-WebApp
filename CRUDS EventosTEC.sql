USE [EventosTEC]
GO

----------------------CRUDS EventType---------------------------------------
-- Crear el tipo de evento "Académico"
INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Académico', 'Eventos de tipo académico');

-- Crear el tipo de evento "Recreativo"
INSERT INTO [dbo].[EventType] ([name], [description])
VALUES ('Recreativo', 'Eventos de tipo recreativo');

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

---------------------CRUDS Event-----------------------------------------
-- Evento 1
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [maxCapacity], [entryCost], [idEventType])
VALUES ('Conferencia de Tecnología', '2023-11-10', 1, 'Una conferencia sobre las últimas tecnologías', 'TechCon', '200', '25', 1);

-- Evento 2
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [maxCapacity], [entryCost], [idEventType])
VALUES ('Feria de Libros', '2023-11-15', 2 'Una feria para amantes de la lectura', 'Book Expo', '300', '0', 2;

-- Evento 3
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [maxCapacity], [entryCost], [idEventType])
VALUES ('Concierto en Vivo', '2023-12-05', 3 'Un concierto de tu banda favorita', 'Live Music Co.', '1000', '50', 2);

-- Evento 4
INSERT INTO [dbo].[Event] ([name], [date], [idEventState], [description], [organizer], [maxCapacity], [entryCost], [idEventType])
VALUES ('Seminario de Marketing', '2023-11-20', 1, 'Aprende estrategias de marketing efectivas', 'Marketing Pro', '150', '30', 1;


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
