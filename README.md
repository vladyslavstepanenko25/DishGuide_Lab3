# DishGuide

## Опис проєкту
DishGuide — це система рекомендацій страв у ресторанах на основі відгуків користувачів.

### Таблиця проєктування тестів (EP та BVA)

| Метод | Параметр | Класи еквівалентності (EP) | Граничні значення (BVA) | Очікуваний результат |
| :--- | :--- | :--- | :--- | :--- |
| `CalculateAverageRating` | `reviews` (List) | **EP1:** Валідний список (>0)<br>**EP2:** Порожній список<br>**EP3:** Список є null<br>**EP4:** Невалідний рейтинг | **BVA1:** Список з 1 елементом<br>**BVA2:** Рейтинг = 1, Рейтинг = 5<br>**BVA3:** Рейтинг = 0, Рейтинг = 6 | **EP1/BVA1/BVA2:** Середнє значення<br>**EP2:** 0<br>**EP3/EP4/BVA3:** Exception |
| `GetTopDishes` | `topCount` (int) | **EP1:** count > 0 (валідні)<br>**EP2:** count < 0 (невалідні)<br>**EP3:** count = 0 | **BVA1:** count = 1<br>**BVA2:** count = розмір списку<br>**BVA3:** count = розмір списку + 1<br>**BVA4:** count = -1 | **EP1/BVA1-BVA3:** Список з ≤ `count` страв<br>**EP3:** Порожній список<br>**EP2/BVA4:** Exception |
| `FilterRestaurants` | `minRating` (double) | **EP1:** 0 ≤ rating ≤ 5<br>**EP2:** rating < 0<br>**EP3:** rating > 5 | **BVA1:** 0.0<br>**BVA2:** 5.0<br>**BVA3:** -0.1<br>**BVA4:** 5.1 | **EP1/BVA1/BVA2:** Відфільтрований список<br>**EP2/EP3/BVA3/BVA4:** Exception |

## Скріншот успішного проходження тестів та з відсотком покриття коду.

<img width="445" height="580" alt="ZPBDIiD04CVlWRp3a8kd2lR3WfHIgU03Y0yGahKDf2aa6r14g8QAWhGUf5SlFa3f1sqJssUOUIDtDwcqWOgdtV_C_lupixkDW9i-3pkkhhdiXWFlWk-qsXninsSMTxgUhfaMx_fWN0VCDy0CG6v-e-Tsn_5KMErqJTSaQ7ejbu5nuGJjoz2n6LpT" src="https://github.com/user-attachments/assets/2dc12beb-a1f8-4b67-8a71-f962df9f70bf" />
