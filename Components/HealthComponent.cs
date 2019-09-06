using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EngineProject.ECS;
using EngineProject.Util;

namespace EngineProject.Components
{
    /// <summary>
    /// Add this to your entity and he'll die >:)
    /// </summary>
    public class HealthComponent : Component
    {
        private int maxHealth;
        private int currentHealth;

        public HealthComponent(int amountOfMaxHealth)
        {
            this.type = ComponentType.HEALTH; 
            this.maxHealth = amountOfMaxHealth;
            this.currentHealth = this.maxHealth;
        }

        public int GetMaxHealth() => this.maxHealth;
        public int GetCurrentHealth() => this.currentHealth;

        public void SetMaxHealth(int amount)
        {
            this.maxHealth = amount;
        }

        /// <summary>
        /// Sets current health.
        /// If current health bigger then max health then current health will be assigned max health
        /// </summary>
        /// <param name="amount"></param>
        public void SetCurrentHealth(int amount)
        {
            if (amount > this.maxHealth)
            {
                this.currentHealth = this.maxHealth;
                return;
            }

            this.currentHealth = amount;
        }

        
    }
}
