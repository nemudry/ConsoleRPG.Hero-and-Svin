﻿using SVINspace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SVINspace
{
    public class CrownOfNazgul : Helmet
    {
        public CrownOfNazgul()
        {
            Name = "Корона назгула";
            Description = "Легендарная корона призрака кольца, очень ценимая \nвсеми злыми героями и добрыми ролевиками. Обычно продаётся " +
                "\nвместе с вороным конём, чёрным плащом и моргульским клинком. \nНо после активного времяпрепровождения в таверне обнаруживается, " +
                "\nчто порванным плащом жена трактирщика вытирает пол, \nкинжал намертво засел в мишени для дартса, а коня ревнивый питомец продал цыганам. " +
                "\nТак что герой отправляется в путешествие в одной зловещей короне, \nк которой налипли яркие ленточки серпантина и блёстки конфети. " +
                "\nНадев корону назгула, герой обнаруживает один интересный эффект. \nВсе слова, произнесённые им, превращаются в злобное шипение, " +
                "\nсопение и душеледенящее завывание. Приходится приложить \nнемало усилий, для того чтобы выговорить фразу внятно. " +
                "\nНо зато эффект устрашения настолько кошмарный, \nчто у некоторых знакомых владельца короны назгула седеют волосы и начинается " +
                "\nнервное заикание от обычного пожелания «Доброго утра». ";
            Price = 7000;
            Bonus = 15;
            RareLevel = Rareness.Легендарная;
            DegreeOfImprovement = degreeOfImprovement.Обычное;
            RaceWears = Hero.raceHero.Любая;
            ClassWears = Hero.classHero.Любая;
        }
    }
}
