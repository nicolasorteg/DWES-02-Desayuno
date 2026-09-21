# Práctica: Desayuno Asíncrono

Implementación de las acciones del desayuno con distintos enfoques de ejecución (secuencial, `async/await`, paralelo) y control de tiempo límite mediante timeout.

## Tabla de tiempos

| # | Solución | Tiempo obtenido | Resultado |
|---|----------|------------------|-----------|
| 1 | Secuencial | ~1543 ms | ✅ Completo |
| 2 | Async/await (secuencial) | ~1538 ms | ✅ Completo |
| 3 | Paralelo (mejor rendimiento) | ~513-526 ms | ✅ Completo |
| 4 | Secuencial + timeout (500 ms) | ~513 ms | ☕ Café frío |
| 5 | Async/await + timeout (500 ms) | ~512 ms | ☕ Café frío |
| 6 | Paralelo + timeout (500 ms) | ~513-526 ms | ⚠️ Variable (a veces ✅, a veces ☕) |

> Los tiempos exactos varían ligeramente entre ejecuciones, pero el orden de magnitud se mantiene estable.

---

## Respuestas

### 1. ¿Qué diferencias has observado entre las 5 soluciones?

La ejecución secuencial y la `async/await` dan tiempos similares puesto que aunque por dentro trabajen distinto, ambas siguen esperando una acción detrás de otra, así que el tiempo total no cambia. Por tanto, el comportamiento observable desde fuera es idéntico.

La versión paralela es la que marca la diferencia. Aquí lo que se hace es lanzar varias cadenas de trabajo a la vez, haciendo uso de la asincronía y el paralelismo. Además, gracias al `Task.WhenAll` se puede esperar solo a la tarea más lenta.


### 2. ¿Qué acciones se pueden ejecutar a la vez y cuáles no? ¿Por qué?

| Cadena | Acciones | Dependencia interna |
|---|---|---|
| 1 | Café | Ninguna |
| 2 | Sartén → (Huevos y Bacon en paralelo) | Huevos y Bacon necesitan la sartén caliente |
| 3 | Pan → Mantequilla | Mantequilla necesita el pan tostado |
| 4 | Zumo | Ninguna |

Las 4 cadenas pueden ejecutarse en paralelo entre sí porque ninguna necesita el resultado de otra. Dentro de la cadena 2, huevos y bacon sí pueden ir en paralelo entre ellos una vez la sartén está caliente, pero ambos necesitan esperar a que la sartén termine primero. Por eso el tiempo total del paralelo no es la suma de todo (1500 ms) ni el mínimo de una sola acción, sino el máximo de las 4 cadenas: la cadena 2 (sartén + fritos) tarda 200 + 300 = 500 ms, y es la que marca el tiempo total.

### 3. ¿Qué ha pasado con cada solución cuando introduces el timeout?

En las versiones secuencial y async/await, el timeout de 500 ms se cumple mucho antes de que el trabajo termine (que tarda ~1500 ms), así que siempre se muestra el mensaje de "café frío". En la versión paralela, el trabajo (~515 ms) y el límite (500 ms) quedan tan cerca que el resultado cambia entre ejecuciones: a veces termina a tiempo, a veces no.


### 4. ¿El enfoque con mejor rendimiento es también el más seguro? ¿Por qué?

No necesariamente. La versión paralela con timeout lo demuestra bien: al llevar el tiempo de ejecución (~515 ms) muy cerca del límite (500 ms), cualquier variación pequeña puede decidir si el resultado es un éxito o un timeout. Ir al límite del rendimiento máximo elimina el margen de seguridad, por lo que un enfoque con menor rendimiento podría llegar a ser más predecible.

### 5. ¿Merece la pena complicarse con paralelismo o con mecanismos de control de tiempo? Justifica tu respuesta.

Con el paralelismo desde luego que sí, en este ejercicio se ve como se reduce el tiempo de carga en 1/3. Es sin duda algo muy rentable, quizás no tanto en tiempos de carga muy bajos, pero en cuanto a un problema real con tiempos de carga más elevados no usar paralelismo sería un error de diseño y algo que podría costar mucho dinero mal invertido.

En cuanto a los mecanismos de control de tiempo diría que depende. Para este ejemplo estos mecanismos son muy útiles porque nos permiten ver con claridad los tiempos de carga de cada proceso. El problema vendría en un problema real con el `Task.WheAny`, ya que esté solo controla el tiempo de espera, no cancela el trabajo de verdad.
