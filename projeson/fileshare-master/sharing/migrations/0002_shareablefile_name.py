# -*- coding: utf-8 -*-
# Generated by Django 1.11.2 on 2017-06-17 20:13
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('sharing', '0001_initial'),
    ]

    operations = [
        migrations.AddField(
            model_name='shareablefile',
            name='name',
            field=models.CharField(default='', max_length=64),
            preserve_default=False,
        ),
    ]
