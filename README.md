# Zartis

La soluci�n ha sido desarrollada por peque�as iteraciones que han sido subidas en micro-commits como se puede ver en el historico de 
cambios de la rama.

A continuaci�n explico cada uno de los commits:

Commit 1: Init Version 
----------------------

Se crea la primera versi�n de la soluci�n, enfoc�ndolo desde TDD. Primero se han hecho los tests, han fallado y se han hecho los 
cambios necesarios para hacerlo funcionar.

Commit 2: Refactor UnitTests for Rocket class. Add Builders: PositionBuilder, LandingAreaMockBuilder and RocketBuilder.
-----------------------------------------------------------------------------------------------------------------------

Se refactoriza los unit tests realizados para la clase Rocket sacando todo lo com�n a una clase abstracta para no duplicar el mismo
c�digo en todos los tests que iban a ser similares. Se a�aden adem�s una serie de Builders para construir m�s f�cilmente los tests y
hacerlos m�s legibles tambi�n.

Commit 3:  Refactor UnitTests for LandingArea class. Add Builders: LandingPlatformMockBuilder and LandingAreaBuilder.
---------------------------------------------------------------------------------------------------------------------

Se aplica la misma refactorizaci�n pero con la clase LandingArea. Ademas se a�aden m�s builders para simplificar todos los tests y 
hacerlos m�s legibles.

Commit 4:  Refactor UnitTests for LandingPlatform class. Add Builders: LandingPlatformBuilder.
----------------------------------------------------------------------------------------------

Se aplica la misma refactorizaci�n pero con la clase LandingPlatform. Ademas se a�aden m�s builders para simplificar todos los tests y 
hacerlos m�s legibles.

Commit 5:  Refactor: Replace logic in LandingArea by the design pattern ChainOfResponsibility.
----------------------------------------------------------------------------------------------

Por �ltimo, se ha sustituido todas las validaciones que hab�a con IF...ELSE en LandingArea por unos validadores desacoplados siguiendo
el patr�n de dise�o ChainOfResponsability. De esta manera si hay que a�adir una nueva validaci�n, no tenemos que tocar nada de las
anteriores validaciones al estar desacopladas totalmente.


APUNTES A RESE�AR:

- He aplicado un enfoque TDD para empezar la aplicaci�n de cero. Todo ha partido de su test correspondiente, primero ha fallado el test
y posteriormente he realizado los cambios necesarios para que el test se pusiera verde.

- Para los test he seguido una estructura GIVEN..WHEN..THEN de Martin Fowler

- Por �ltimo, hubiera a�adido una peque�a aplicaci�n de consola con una generaci�n de cohetes aleatorios para ir viendo por consola como
iban procesando las preguntas de las posiciones. Pero como se hac�a hincapie en que solo se haga la librer�a y sus tests no la he hecho
al final.