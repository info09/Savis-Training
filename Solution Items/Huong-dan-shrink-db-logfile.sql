-- HUONG DAN
-- Buoc 1. Right click vao ten Database, chon Task > Shrink > Files
-- Buoc 2. Lua chon File type : Log
-- Buoc 3. Nhap ten file log trong dropdown File name vao bien @DbLogFile duoi day.
--			vi du o day ten File name la SAVIS.CoreFW_V24_log
-- Buoc 4. Thay ten Database, chay script ben duoi

-- Db Log file name
Declare @DbLogFile nvarchar = 'SAVIS.CoreFW_V24_log'

-- Start
USE [SAVIS.CoreFW.TCCNTT]

-- Truncate the log by changing the database recovery model to SIMPLE.
ALTER DATABASE [SAVIS.CoreFW.TCCNTT]
SET RECOVERY SIMPLE;
GO

-- Shrink the truncated log file to 1 MB.
DBCC SHRINKFILE (N'SAVIS.CoreFW_V24_log', 1);
GO

-- Reset the database recovery model.
ALTER DATABASE [SAVIS.CoreFW.TCCNTT]
SET RECOVERY FULL;
GO



--CLEAN ORPHAN PARAGRAPH
delete from cms_Paragraph
where ParagraphID NOT IN
(
select ObjectID from cms_StorylineLayout
where TableName = 'Paragraph'
)



-- SELECT USED SPACES
-- METHOD 1

SELECT 
    t.NAME AS TableName,
    i.name as indexName,
    p.[Rows],
    sum(a.total_pages) as TotalPages, 
    sum(a.used_pages) as UsedPages, 
    sum(a.data_pages) as DataPages,
    (sum(a.total_pages) * 8) / 1024 as TotalSpaceMB, 
    (sum(a.used_pages) * 8) / 1024 as UsedSpaceMB, 
    (sum(a.data_pages) * 8) / 1024 as DataSpaceMB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
WHERE 
    t.NAME NOT LIKE 'dt%' AND
    i.OBJECT_ID > 255 AND   
    i.index_id <= 1
GROUP BY 
    t.NAME, i.object_id, i.index_id, i.name, p.[Rows]
ORDER BY 
    object_name(i.object_id), TotalSpaceMB

-- METHOD 2
SELECT 
    t.NAME AS TableName,
    s.Name AS SchemaName,
    p.rows AS RowCounts,
    SUM(a.total_pages) * 8 AS TotalSpaceKB, 
    SUM(a.used_pages) * 8 AS UsedSpaceKB, 
    (SUM(a.total_pages) - SUM(a.used_pages)) * 8 AS UnusedSpaceKB
FROM 
    sys.tables t
INNER JOIN      
    sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN 
    sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN 
    sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN 
    sys.schemas s ON t.schema_id = s.schema_id
WHERE 
    t.NAME NOT LIKE 'dt%' 
    AND t.is_ms_shipped = 0
    AND i.OBJECT_ID > 255 
GROUP BY 
    t.Name, s.Name, p.Rows
ORDER BY 
    t.Name
	--------


