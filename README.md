# Zartis

La solución ha sido desarrollada por pequeñas iteraciones que han sido subidas en micro-commits como se puede ver en el historico de 
cambios de la rama.

A continuación explico cada uno de los commits:

Commit 1: Init Version 
----------------------

Se crea la primera versión de la solución, enfocándolo desde TDD. Primero se han hecho los tests, han fallado y se han hecho los 
cambios necesarios para hacerlo funcionar.

Commit 2: Refactor UnitTests for Rocket class. Add Builders: PositionBuilder, LandingAreaMockBuilder and RocketBuilder.
-----------------------------------------------------------------------------------------------------------------------

Se refactoriza los unit tests realizados para la clase Rocket sacando todo lo común a una clase abstracta para no duplicar el mismo
código en todos los tests que iban a ser similares. Se añaden además una serie de Builders para construir más fácilmente los tests y
hacerlos más legibles también.

Commit 3:  Refactor UnitTests for LandingArea class. Add Builders: LandingPlatformMockBuilder and LandingAreaBuilder.
---------------------------------------------------------------------------------------------------------------------

Se aplica la misma refactorización pero con la clase LandingArea. Ademas se añaden más builders para simplificar todos los tests y 
hacerlos más legibles.

Commit 4:  Refactor UnitTests for LandingPlatform class. Add Builders: LandingPlatformBuilder.
----------------------------------------------------------------------------------------------

Se aplica la misma refactorización pero con la clase LandingPlatform. Ademas se añaden más builders para simplificar todos los tests y 
hacerlos más legibles.

Commit 5:  Refactor: Replace logic in LandingArea by the design pattern ChainOfResponsibility.
----------------------------------------------------------------------------------------------

Por último, se ha sustituido todas las validaciones que había con IF...ELSE en LandingArea por unos validadores desacoplados siguiendo
el patrón de diseño ChainOfResponsability. De esta manera si hay que añadir una nueva validación, no tenemos que tocar nada de las
anteriores validaciones al estar desacopladas totalmente.


APUNTES A RESEÑAR:

- He aplicado un enfoque TDD para empezar la aplicación de cero. Todo ha partido de su test correspondiente, primero ha fallado el test
y posteriormente he realizado los cambios necesarios para que el test se pusiera verde.

- Para los test he seguido una estructura GIVEN..WHEN..THEN de Martin Fowler

- Por último, hubiera añadido una pequeña aplicación de consola con una generación de cohetes aleatorios para ir viendo por consola como
iban procesando las preguntas de las posiciones. Pero como se hacía hincapie en que solo se haga la librería y sus tests no la he hecho
al final.