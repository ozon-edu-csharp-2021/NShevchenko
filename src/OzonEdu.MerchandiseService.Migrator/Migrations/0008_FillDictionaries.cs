using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(8)]
    public class FillDictionaries:ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merch_packs (id, merch_pack_name, description, is_repeatable)
                VALUES 
                    (10, 'WelcomePack', 'Набор мерча, выдаваемый сотруднику при устройстве на работу.', 1),
                    (20, 'ConferenceListenerPack', 'Набор мерча, выдаваемый сотруднику при посещении конференции в качестве слушателя.', 0),
                    (30, 'ConferenceSpeakerPack', 'Набор мерча, выдаваемый сотруднику при посещении конференции в качестве спикера.', 0),
                    (40, 'ProbationPeriodEndingPack', 'Набор мерча, выдаваемый сотруднику при успешном прохождении испытательного срока.', 1),
                    (50, 'VeteranPack', 'Набор мерча, выдаваемый сотруднику за выслугу лет.', 1)
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO item_types (id, item_type_name, description)
                VALUES 
                    (1, 'TShirt', 'Футболка с надписью OZON'),
                    (2, 'SweatshirtGradient', 'Толстовка градиентная'),
                    (3, 'Sweatshirt', 'Толстовка с надписью OZON'),
                    (4, 'RainCoat', 'Дождевик'),   
                    (5, 'Notepad', 'Блокнот'),
                    (6, 'Bag', 'Сумка'),
                    (7, 'BagPack', 'Рюкзак'),
                    (8, 'Pen','Ручка'),
                    (9, 'Socks','Носки')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO clothing_sizes (id, size_name, item_type_id)
                VALUES 
                    --TShirt
                    (1, 'XS', 1),
                    (2, 'S', 1),
                    (3, 'M', 1),
                    (4, 'L', 1),   
                    (5, 'XL', 1),
                    --SweatshirtGradient
                    (6, 'XS', 2),
                    (7, 'S', 2),
                    (8, 'M', 2),
                    (9, 'L', 2),   
                    (10, 'XL', 2),
                    --Sweatshirt
                    (11, 'XS', 3),
                    (12, 'S', 3),
                    (13, 'M', 3),
                    (14, 'L', 3),   
                    (15, 'XL', 3),
                    --RainCoat
                    (16, 'Small', 4),
                    (17, 'Large', 4),
                    --Socks
                    (18, '36-39', 9),
                    (19, '39-45', 9)                    
                ON CONFLICT DO NOTHING
            ");

            Execute.Sql(@"
                INSERT INTO merch_pack_items (id, merch_pack_id, item_type_id, quantity)
                VALUES 
                    --WelcomePack
                    (1, 10, 1, 1),
                    (2, 10, 9, 1),
                    (3, 10, 5, 3),
                    (4, 10, 6, 1),
                    (5, 10, 8, 3),
                    --ConferenceListenerPack
                    (6, 20, 5, 1),
                    (7, 20, 7, 1),
                    (8, 20, 8, 1),
                    --ConferenceSpeakerPack
                    (9, 30, 5, 1),
                    (10, 30, 7, 1),
                    (11, 30, 8, 1),
                    (12, 30, 3, 1),                       
                    --ProbationPeriodEndingPack
                    (13, 40, 2, 1),
                    (14, 40, 7, 1),
                    (15, 40, 9, 1),
                    (16, 40, 1, 2),
                    --VeteranPack
                    (17, 50, 3, 1),
                    (18, 50, 4, 1),
                    (19, 50, 9, 1),
                    (20 50, 5, 2)           
                ON CONFLICT DO NOTHING
            ");
        }
    }
}