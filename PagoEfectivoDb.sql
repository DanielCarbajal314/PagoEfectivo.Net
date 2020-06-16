CREATE TABLE PagoEfectivoPayments
(
	TransactionCode INT IDENTITY
	,AdditionalData VARCHAR(50) NOT NULL
	,AdminEmail VARCHAR(50) NOT NULL
	,Amount DECIMAL(18,2) NOT NULL
	,Currency VARCHAR(3) NOT NULL
	,DateExpiry DATETIME
	,PaymentConcept VARCHAR(30)
	,UserCodeCountry VARCHAR(50)
	,UserCountry VARCHAR(30)
	,UserDocumentNumber VARCHAR(15)
	,UserDocumentType VARCHAR(3)
	,UserEmail VARCHAR(50)
	,UserLastName VARCHAR(30)
	,UserName VARCHAR(30)
	,UserPhone VARCHAR(12)
	,UserUbigeo VARCHAR(9)
	,Cip INT NULL
	,OperationNumber INT NULL
	,EventType VARCHAR(100)
	,paymentDate DATETIME NULL
	,CipUrl VARCHAR(300)
	PRIMARY KEY(TransactionCode)
)
GO

CREATE PROCEDURE RegisterPagoEfectivoPayments
(
	@AdditionalData VARCHAR(50),
	@AdminEmail VARCHAR(50),
	@Amount DECIMAL(18,2),
	@Currency VARCHAR(3),
	@DateExpiry DATETIME,
	@PaymentConcept VARCHAR(30),
	@UserCodeCountry VARCHAR(50),
	@UserCountry VARCHAR(30),
	@UserDocumentNumber VARCHAR(15),
	@UserDocumentType VARCHAR(3),
	@UserEmail VARCHAR(50),
	@UserLastName VARCHAR(30),
	@UserName VARCHAR(30),
	@UserPhone VARCHAR(12),
	@UserUbigeo VARCHAR(9))
AS
BEGIN

	INSERT INTO PagoEfectivoPayments(
		AdditionalData,
		AdminEmail,
		Amount,
		Currency,
		DateExpiry,
		PaymentConcept,
		UserCodeCountry,
		UserCountry,
		UserDocumentNumber,
		UserDocumentType,
		UserEmail,
		UserLastName,
		UserName,
		UserPhone,
		UserUbigeo)
	VALUES(
		@AdditionalData,
		@AdminEmail,
		@Amount,
		@Currency,
		@DateExpiry,
		@PaymentConcept,
		@UserCodeCountry,
		@UserCountry,
		@UserDocumentNumber,
		@UserDocumentType,
		@UserEmail,
		@UserLastName,
		@UserName,
		@UserPhone,
		@UserUbigeo)
	SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE UpdateCiffOnPagoEfectivoPayments(
	@TransaccionCode INT,
	@Cip INT,
	@CipUrl VARCHAR(300))
AS
BEGIN
	UPDATE PagoEfectivoPayments
	SET Cip = @Cip, CipUrl = @CipUrl
	WHERE TransactionCode = @TransaccionCode
END

GO

CREATE PROCEDURE RegisterPaymentOnPagoEfectivoPayments(
	@TransaccionCode INT,
	@OperationNumber INT,
	@paymentDate Datetime,
	@EventType VARCHAR(100))
AS
BEGIN
	UPDATE PagoEfectivoPayments
	SET OperationNumber = @OperationNumber, paymentDate = @paymentDate, EventType = @EventType
	WHERE TransactionCode = @TransaccionCode
END
