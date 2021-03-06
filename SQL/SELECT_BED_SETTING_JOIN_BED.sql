﻿SELECT SETTING.DESCRIPTION AS SETTING, BED.DESCRIPTION AS BED, COUNT(BED.ID_PK)
FROM BED_SETTING, BED, SETTING
WHERE BED_SETTING.BED_FK = BED.ID_PK
AND BED_SETTING.SETTING_FK = SETTING.ID_PK
GROUP BY SETTING.DESCRIPTION, BED.DESCRIPTION
ORDER BY SETTING.DESCRIPTION