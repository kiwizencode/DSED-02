SELECT ROOM_FK, ITEM.DESCRIPTION, COST, MAX, COUNT(ITEM_FK) AS COUNT
FROM ROOM_ITEM, ITEM
WHERE ITEM_FK = ITEM.PK_ID
GROUP BY ROOM_FK, ITEM.DESCRIPTION, COST, MAX
ORDER BY ROOM_FK