using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gudi_project
{
    /*
    아쉬운점: 테이블 구조에서 상품 -> conn <- 여행지 보다
                상품 -> 날자 -> conn <- 여행지 형식이 더 나은 선택이었을 것이다. 이로인해 Image의 반복을 줄이고
                BLOB의 형태로 이미지를 넣어도 서버의 데이터 양이 적었을 것이다.

    */

    /* 
     *  
     *  DELIMITER $$
    create procedure da(IN fromdate varchar(30), in todate varchar(30))
    BEGIN
    SET sql_mode = '';
    SET @sql = NULL;
   
    SELECT GROUP_CONCAT(DISTINCT CONCAT('sum(case when res_date = ''',res_date,''' then res_prce else 0 end) as ''' , res_date,'''' )) INTO @sql
    from reservation where res_date >= fromdate and  res_date <= todate;

    -- sum(case when res_date = '2020-11-09' then res_prce else 0 end) '2020-11-09'

    SET @sql = CONCAT('select travel_info.trv_info_name, ', @sql,
    ' FROM reservation join travel_info on travel_info.trv_info_ID = reservation.trv_info_ID
    group by travel_info.trv_info_name; ');

    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

    END $$
    DELIMITER ;
     */
    class test
    {
        private void XmlTest01()
        {
            String URLString = "https://tour.chungnam.go.kr/_prog/openapi/?func=tour&mode=getCnt";
            XmlTextReader reader = new XmlTextReader(URLString);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        Debug.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute()) // Read the attributes.
                            Debug.Write(" " + reader.Name + "='" + reader.Value + "'");
                        Debug.Write(">");
                        Debug.WriteLine(">");
                        break;
                    case XmlNodeType.Text: //Display the text in each element.
                        Debug.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EndElement: //Display the end of the element.
                        Debug.Write("</" + reader.Name);
                        Debug.WriteLine(">");
                        break;
                }
            }

        }
    }
}
