SELECT resolvedpath_paperomr AS Path 
FROM   paperomr_tbl 
JOIN   paperomrid_tbl 
ON     paperomr_tbl .id_paperomr =paperomrid_tbl.id_paperomr 
WHERE  error_exit IS NULL 
AND    ( 
              d0_paperomrid LIKE '_' 
       AND    d1_paperomrid LIKE '_' 
       AND    d2_paperomrid LIKE '_' 
       AND    d3_paperomrid LIKE '_' --i know bade farjik one more thing need your opinion 
       AND    d4_paperomrid LIKE '_' 
       AND    d4_paperomrid LIKE '_') 
AND    id_scan=86 
AND    id_type <> 
       ( 
              SELECT id_type 
              FROM   exams_type 
              WHERE  name_type='error') 
AND    paperomr_tbl.id_paperomr NOT IN 
       ( 
              SELECT T7.id_paperomr 
              FROM   ( 
                            SELECT T12.d0_paperomrid , 
                                   T12.d1_paperomrid , 
                                   T12.d2_paperomrid , 
                                   T12.d3_paperomrid , 
                                   T12.d4_paperomrid 
                            FROM   ( 
                                          SELECT T1.d0_paperomrid , 
                                                 t1.d1_paperomrid , 
                                                 T1 .d2_paperomrid , 
                                                 T1.d3_paperomrid , 
                                                 t1.d4_paperomrid 
                                          FROM   paperomrid_tbl AS T1 
                                          JOIN   paperomr_tbl   AS T2 
                                          ON     T1.id_paperomr =T2.id_paperomr 
                                          WHERE  T2.id_scan =86) AS T12 
                            JOIN 
                                   ( 
                                          SELECT T3.d0_paperomrid , 
                                                 T3.d1_paperomrid , 
                                                 T3 .d2_paperomrid , 
                                                 T3.d3_paperomrid , 
                                                 T3.d4_paperomrid 
                                          FROM   paperomrid_tbl AS T3 
                                          JOIN   paperomr_tbl   AS T4 
                                          ON     T3.id_paperomr =T4.id_paperomr 
                                          WHERE  T4.id_scan <>86 
                                          AND    T4.id_scan IN 
                                                 ( 
                                                        SELECT TscanId2 .id_scan 
                                                        FROM   scan_tbl AS TscanId1 
                                                        JOIN   scan_tbl AS TscanId2 
                                                        ON     TscanId1 .name_exam_scan =TscanId2 .name_exam_scan
                                                        AND    TscanId1 .name_language_scan =TscanId2 .name_language_scan
                                                        WHERE  TscanId1 .id_scan =86)) AS T34
                            ON     T12.d0_paperomrid=T34.d0_paperomrid 
                            AND    T12.d1_paperomrid=T34.d1_paperomrid 
                            AND    T12.d2_paperomrid=T34.d2_paperomrid 
                            AND    T12.d3_paperomrid=T34.d3_paperomrid 
                            AND    T12.d4_paperomrid=T34.d4_paperomrid ) AS T5 
              JOIN   paperomrid_tbl                                      AS T6
              ON     T5.d0_paperomrid=T6.d0_paperomrid 
              AND    T5.d1_paperomrid=T6.d1_paperomrid 
              AND    T5.d2_paperomrid=T6.d2_paperomrid 
              JOIN   paperomr_tbl AS T7 
              ON     T6.id_paperomr =T7 .id_paperomr 
              WHERE  ( 
                            T6.id_paperomr IN 
                            ( 
                                   SELECT id_paperomr 
                                   FROM   paperomr_tbl 
                                   WHERE  id_scan IN 
                                          ( 
                                                 SELECT TscanId2 .id_scan 
                                                 FROM   scan_tbl AS TscanId1 
                                                 JOIN   scan_tbl AS TscanId2 
                                                 ON     TscanId1 .name_exam_scan =TscanId2 .name_exam_scan
                                                 AND    TscanId1 .name_language_scan =TscanId2 .name_language_scan
                                                 WHERE  TscanId1 .id_scan =86)) 
                     AND    T5.d3_paperomrid=T6.d3_paperomrid 
                     AND    T5.d4_paperomrid=T6.d4_paperomrid) )