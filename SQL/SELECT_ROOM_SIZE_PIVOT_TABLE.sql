﻿SELECT ROOM.DESCRIPTION, [SINGLE], [DOUBLE], MAX_CAPACITY, TOTAL
FROM VIEW_BED_SETTING_PIVOT_TABLE, ROOM
WHERE ROOM.SETTING_FK = VIEW_BED_SETTING_PIVOT_TABLE.ID_PK